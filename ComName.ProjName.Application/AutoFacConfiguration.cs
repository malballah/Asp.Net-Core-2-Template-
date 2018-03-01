using Autofac;
using Autofac.Extensions.DependencyInjection;
using ComName.ProjName.Abstraction;
using ComName.ProjName.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ComName.ProjName.Application
{
    public class AutoFacConfiguration
    {
        public static IContainer Container { get; private set; }

        public static IServiceProvider Configure(IServiceCollection services)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();
            
            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            //
            // Note that Populate is basically a foreach to add things
            // into Autofac that are in the collection. If you register
            // things in Autofac BEFORE Populate then the stuff in the
            // ServiceCollection can override those things; if you register
            // AFTER Populate those registrations can override things
            // in the ServiceCollection. Mix and match as needed.
            builder.Populate(services);
            RegisterTypes(builder);
            Container = builder.Build();
            
            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(Container);
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            // Add application services.     
            builder.RegisterType<ApplicationService>().As<IApplicationService>().InstancePerLifetimeScope();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(DbService<>)).As(typeof(IDbService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<AppSession>().As<IAppSession>().InstancePerLifetimeScope();
        }
    }
}
