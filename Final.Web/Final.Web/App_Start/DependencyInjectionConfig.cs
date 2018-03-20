using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using Final.Web.Models;
using Final.Web.Repositories;
using Final.Web.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Final.Web.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<ICarRepository, CarRepository>(Lifestyle.Scoped);
            container.Register<ICarService, CarService>(Lifestyle.Scoped);

            container.Register<IProjectRepository, ProjectRepository>(Lifestyle.Scoped);
            container.Register<IProjectService, ProjectService>(Lifestyle.Scoped);

            container.Register<IShoeRepository, ShoeRepository>(Lifestyle.Scoped);
            container.Register<IShoeService, ShoeService>(Lifestyle.Scoped);


            //container.Register <ApplicationUserManager, ApplicationUserManager> (Lifestyle.Scoped);
            //container.Register<ApplicationSignInManager, ApplicationSignInManager>(Lifestyle.Scoped);

            //container.Register <ApplicationUser, ApplicationUser> (Lifestyle.Scoped);
            //container.Register<IUserStore<ApplicationUser>, SingleConstructorUserStore>(Lifestyle.Scoped);

            
            


            //container.Register <, > (Lifestyle.Scoped);
            //container.Register<, >(Lifestyle.Scoped);


            container.Register<ApplicationDbContext, ApplicationDbContext>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}