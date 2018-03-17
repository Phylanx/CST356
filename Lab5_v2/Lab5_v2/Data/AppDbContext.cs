using Lab5_v2.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

namespace Lab5_v2.Data
{
    public class AppDbContext : DbContext, IAppContext
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
        public virtual DbSet<Shoes> Shoes { get; set; }
        
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext> { }
}