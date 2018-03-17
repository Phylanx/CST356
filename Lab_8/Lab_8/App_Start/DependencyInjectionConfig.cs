using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Services.Description;
using Lab_8.Data;
using Lab_8.Repositories;
using Lab_8.Services;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Week8_WebApp1.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<IRepository, Repository>(Lifestyle.Scoped);
            container.Register<IService, Lab_8.Services.Service>(Lifestyle.Scoped);
            container.Register<IAppDB, AppDbContext>(Lifestyle.Scoped);

            //            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>());

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}