using LabWork8;

using (ApplicationContext db = new ApplicationContext())
{
    // создаем два объекта User
    Viewer tom = new Viewer { id = 1, phone = "+79876543210", name = "Tom", birthDate = 33, email = "example@gmail.com" };
    Viewer alice = new Viewer { name = "Alice", birthDate = 26 };

    // добавляем их в бд
    db.Viewers.Add(tom);
    db.Viewers.Add(alice);
    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    // получаем объекты из бд и выводим на консоль
    var users = db.Viewers.ToList();
    Console.WriteLine("Список объектов:");
    foreach (Viewer u in users)
    {
        Console.WriteLine($"{u.id}.{u.name} - {u.BirthDate}");
    }
}