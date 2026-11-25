using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lection2411
{
   public class User
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    } 
    
    public class Admin : User
    {
        public string Phone { get; set; } = null!;
        public string? Salary { get; set; } = null!;
    }

    [Table("Customers")]
    public class Customer : User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Address { get; set; } = null!;
    }
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public UsersContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = test3.db");
        }
    }
}
