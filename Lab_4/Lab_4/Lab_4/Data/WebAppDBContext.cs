
using Lab_4.Data.Entities;
using System.Data.Entity;

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

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public System.Data.Entity.DbSet<Lab_4.Models.ProjectModel> ProjectModels { get; set; }
    }

    public class WebAppDBInitializer : DropCreateDatabaseIfModelChanges<WebAppDBContext>
    {
        // intentionally left blank
    }
}
