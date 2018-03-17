﻿using System.Data.Entity;
using System.Reflection;
using System.Web.Mvc;
using Lab5_v3.Data;
using Lab5_v3.Repositories;
using Lab5_v3.Services;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Lab5_v3.App_Start
{
    public class DependencyInjectionConfig
    {
        public static void Register()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IPCRepository, PCRepository>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IPCService, PCService>(Lifestyle.Scoped);
            container.Register<AppDbContext, AppDbContext>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}