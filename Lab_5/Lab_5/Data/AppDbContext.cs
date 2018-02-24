using Lab_5.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab_5.Data
{
    public class AppDbContext : DbContext, IDbContext
    {
        public AppDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PC> PCs { get; set; }

        public void SaveContextChanges()
        {
            SaveChanges();
        }

        public System.Data.Entity.DbSet<Lab_5.Models.UserViewModel> UserViewModels { get; set; }

        public System.Data.Entity.DbSet<Lab_5.Models.PCViewModel> PCViewModels { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        // intentionally left blank
    }
}