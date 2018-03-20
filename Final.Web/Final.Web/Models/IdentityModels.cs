
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Final.UserEntities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Final.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new AppDbInitializer());
            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Shoe> Shoes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public System.Data.Entity.DbSet<Final.Web.Models.Entities.ShoeModel> ShoeModels { get; set; }

        public System.Data.Entity.DbSet<Final.Web.Models.Entities.CarModel> CarModels { get; set; }

        public System.Data.Entity.DbSet<Final.Web.Models.Entities.ProjectModel> ProjectModels { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    { /*intentionally left blank*/ }



    //end namespace
}