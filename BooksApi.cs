#:sdk Microsoft.NET.Sdk.Web
#:property TargetFramework=net10.0
#:property PublishAot=false

// Учебный стенд: dotnet run --file BooksApi.cs
// Данные существуют только в памяти процесса. Внешние пакеты и база данных не нужны.
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var gate = new object();
var books = new Dictionary<int, Book>();
var nextId = 3;
Reset();

app.MapGet("/", () => Results.Ok(new
{
    name = "Books API",
    collection = "/books",
    reset = "/testing/reset"
}));

// q — необязательная подстрока названия; порядок результатов всегда по id.
app.MapGet("/books", (string? q) =>
{
    lock (gate)
    {
        var query = books.Values.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(q))
            query = query.Where(book => book.Title.Contains(q.Trim(), StringComparison.OrdinalIgnoreCase));

        return Results.Ok(query.OrderBy(book => book.Id).ToArray());
    }
});

app.MapGet("/books/{id:int}", (int id) =>
{
    lock (gate)
    {
        return books.TryGetValue(id, out var book)
            ? (IResult)Results.Ok(book)
            : MissingBook(id);
    }
});

app.MapPost("/books", (BookInput input) =>
{
    var errors = Validate(input);
    if (errors.Count > 0)
        return (IResult)Results.ValidationProblem(errors);

    lock (gate)
    {
        var book = new Book(nextId++, input.Title!.Trim(), input.Author!.Trim());
        books.Add(book.Id, book);
        return Results.Created($"/books/{book.Id}", book);
    }
});

// PUT полностью заменяет редактируемые поля; оба поля обязательны.
app.MapPut("/books/{id:int}", (int id, BookInput input) =>
{
    lock (gate)
    {
        if (!books.ContainsKey(id))
            return MissingBook(id);

        var errors = Validate(input);
        if (errors.Count > 0)
            return (IResult)Results.ValidationProblem(errors);

        var book = new Book(id, input.Title!.Trim(), input.Author!.Trim());
        books[id] = book;
        return Results.Ok(book);
    }
});

app.MapDelete("/books/{id:int}", (int id) =>
{
    lock (gate)
    {
        return books.Remove(id)
            ? (IResult)Results.NoContent()
            : MissingBook(id);
    }
});

// Служебная операция стенда: возвращает исходные данные и счётчик id.
// Сброс нужен только перед независимым учебным прогоном коллекции.
app.MapPost("/testing/reset", () =>
{
    lock (gate)
    {
        Reset();
        return Results.Ok(new { count = books.Count, nextId });
    }
});

// Имитация проверки заголовка для упражнений. Это не JWT и не промышленная авторизация.
app.MapGet("/protected/ping", (HttpContext context) =>
{
    if (context.Request.Headers.Authorization.ToString() != "Bearer training-token")
    {
        context.Response.Headers.WWWAuthenticate = "Bearer";
        return (IResult)Results.Problem(
            statusCode: 401,
            title: "Требуется учебный токен",
            detail: "Передайте Authorization: Bearer training-token.");
    }

    return Results.Ok(new { message = "Учебный токен принят" });
});

app.Run(builder.Configuration["urls"] ?? "http://127.0.0.1:5080");

void Reset()
{
    books.Clear();
    books.Add(1, new Book(1, "Алгоритмы для начинающих", "Анна Смирнова"));
    books.Add(2, new Book(2, "Тестирование API", "Иван Петров"));
    nextId = 3;
}

static IResult MissingBook(int id) => Results.Problem(
    statusCode: 404,
    title: "Книга не найдена",
    detail: $"Книга с id={id} отсутствует.");

static Dictionary<string, string[]> Validate(BookInput input)
{
    var errors = new Dictionary<string, string[]>();

    if (string.IsNullOrWhiteSpace(input.Title))
        errors["title"] = ["Название обязательно."];
    else if (input.Title.Trim().Length > 100)
        errors["title"] = ["Название должно содержать не более 100 символов UTF-16."];

    if (string.IsNullOrWhiteSpace(input.Author))
        errors["author"] = ["Автор обязателен."];
    else if (input.Author.Trim().Length > 80)
        errors["author"] = ["Имя автора должно содержать не более 80 символов UTF-16."];

    return errors;
}

record Book(int Id, string Title, string Author);
record BookInput(string? Title, string? Author);
