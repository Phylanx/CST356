
using Lab_4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab_4.Data
{
    public class WebAppDBContext : DbContext
    {
        public WebAppDBContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new WebAppDBInitializer());
        }

        public virtual DbSet<UserModel> Users { get; set; }

        public virtual DbSet<ProjectModel> Projects { get; set; }
    }

    public class WebAppDBInitializer : DropCreateDatabaseIfModelChanges<WebAppDBContext>
    {
        // intentionally left blank
    }
}
