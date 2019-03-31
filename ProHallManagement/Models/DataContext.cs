using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProHallManagement.Models
{
    public class DataContext : DbContext
    {



        public DataContext() : base("DbConnect")
        {
        }

        public DbSet<Teacher> Teachers { get; set; }


        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Session> Sessions { get; set; }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Work> Works { get; set; }

        public DbSet<Notification> Notificatons { get; set; }
        public DbSet<UPost> UPosts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<UComment> UComments { get; set; }
        public DbSet<PImage> PImages { get; set; }


        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<UImage> UImages { get; set; }
        public DbSet<UAlbum> UAlbums { get; set; }


    }
}