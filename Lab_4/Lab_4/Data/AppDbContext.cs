using System.Data.Entity;
using Lab_4.Data.Entities;

namespace Lab_4.Data
{
    public class AppDbContext : DbContext
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

        public System.Data.Entity.DbSet<Lab_4.Models.UserViewModel> UserViewModels { get; set; }

        public System.Data.Entity.DbSet<Lab_4.Models.PCViewModel> PCViewModels { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        // intentionally left blank
    }
}
