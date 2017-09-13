using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Contrucks.Controllers;
using Contrucks.Models;
using Contrucks.Repository.Infrastructure;
using Contrucks.Repository.Repository;
using Contrucks.Service;
using Contrucks.Service.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Contrucks
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Setup the Container Builder
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();


            //Identity Account controller binding using autofac


            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerLifetimeScope();
            builder.Register<IdentityFactoryOptions<ApplicationUserManag‌​er>>(c => new IdentityFactoryOptions<ApplicationUserManager>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionPr‌​ovider("ApplicationN‌​ame")
            });
            builder.RegisterType<ApplicationUserManager>().AsSelf().Inst‌​ancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication);
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterFilterProvider();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<ApplicationUserStore>().As<IUserStore<PortalUser>>().InstancePerLifetimeScope();
            // builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();


            builder.RegisterControllers(typeof(AccountController).Assembly);
            






            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();

            // Register your repositories all at once using assembly scanning
            builder.RegisterAssemblyTypes(typeof(UserTablesRepository).Assembly).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(UserTablesService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<RecentJobPostService>().As<IRecentJobPostService>().InstancePerRequest();
            builder.RegisterType<RecentpostsRepository>().As<IRecentpostsRepository>().InstancePerRequest();

            builder.RegisterType<UserTablesRepository>().As<IUserTablesRepository>().InstancePerRequest();
            builder.RegisterType<UserTablesService>().As<IUserTablesService>().InstancePerRequest();
            // Register your Web API controllers all at once using assembly scanning
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
            //app.UseAutofacMiddleware(container);
            //app.UseAutofacMvc();
            //ConfigureAuth(app);
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //var resolver = new AutofacWebApiDependencyResolver(container);
            //GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
    }

