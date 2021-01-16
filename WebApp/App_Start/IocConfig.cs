using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebApp.Core;
using WebApp.Core.Entities;
using WebApp.Core.Services;
using WebApp.Data;
using WebApp.Services;

namespace WebApp.App_Start
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            RegisterMVCDependencies(container);
            RegisterServices(container);

            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void RegisterServices(Container container)
        {
            container.Register<ILaptopService, LaptopService>(Lifestyle.Scoped);
            container.Register(typeof(IRepository<>), typeof(Repository<>), Lifestyle.Scoped);
        }

        private static void RegisterMVCDependencies(Container container)
        {
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
            container.Register<UserManager<ApplicationUser, string>>(
                  () => new UserManager<ApplicationUser, string>(new UserStore<ApplicationUser>()),
      Lifestyle.Scoped);

            container.Options.ResolveUnregisteredConcreteTypes = true;
            container.Register<IUserStore<ApplicationUser>>(
       () => new UserStore<ApplicationUser>(
         container.GetInstance<ApplicationDbContext>()),
       Lifestyle.Scoped);
            //       container.RegisterInitializer<ApplicationUserManager>(
            //manager => InitializeUserManager(manager, app));
            container.Register<SignInManager<ApplicationUser, string>, ApplicationSignInManager>(
           Lifestyle.Scoped);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Register<IAuthenticationManager>(() =>
    container.IsVerifying
        ? new OwinContext(new Dictionary<string, object>()).Authentication
        : HttpContext.Current.GetOwinContext().Authentication,
    Lifestyle.Scoped);
        }
    }
}