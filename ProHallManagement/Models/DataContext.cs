using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }


        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Session> Sessions { get; set; }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Work> Works { get; set; }

        public DbSet<Notification> Notificatons { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }


    }
}