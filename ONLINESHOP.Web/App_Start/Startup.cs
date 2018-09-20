using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using ONLINESHOP.Data;
using ONLINESHOP.Data.Infrastructure;
using ONLINESHOP.Data.Repositories;
using ONLINESHOP.Model.Models;
using ONLINESHOP.Service;
using Owin;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(ONLINESHOP.Web.App_Start.Startup))]

namespace ONLINESHOP.Web.App_Start
{
    public partial class Startup

    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);

            ConfigureAuth(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerDependency();

            builder.RegisterType<ONLINESHOPDBCONTEXT>().AsSelf().InstancePerDependency();

            //Asp.net Identity
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerDependency();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerDependency();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerDependency();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerDependency();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerDependency();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(PostCategoryRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerDependency();

            // Services

            builder.RegisterAssemblyTypes(typeof(PostCategoryService).Assembly);

            builder.RegisterAssemblyTypes(typeof(ErrorService).Assembly)

               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerDependency();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}