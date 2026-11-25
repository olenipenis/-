using Lection2411;

Console.WriteLine("EAV");

using var context = new UsersContext();

var admin = new Admin()
{
    Id = 1,
    Login = "admin",
    Password = "qwe",
    Phone = "+7900"
};
context.Admins.Add(admin);
context.SaveChanges();

var customer = new Customer()
{
    Id = 1,
    Login = "Admin",
    Password = "qwe",
    FullName = "Петя"
};
context.Admins.Add(customer);
context.SaveChanges();

var admins = context.Users.OfType<Admin>().ToList();
var customers = context.Users.OfType<Customer>().ToList();

var users = context.Users.ToList();

var admins2 = context.Admins.ToList();
Console.WriteLine();