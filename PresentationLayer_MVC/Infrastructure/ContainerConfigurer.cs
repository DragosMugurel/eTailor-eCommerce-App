using BusinessLayer.Interfaces;
using BusinessLayer;
using DataAccessLayer_ORM_CF;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using BusinessLayer.CoreServices.Interfaces;
using BusinessLayer.CoreServices;
using DataAccessLayer_ORM_CF.Interfaces;
using System;

namespace PresentationLayer_MVC.Infrastructure
{
    public class ContainerConfigurer
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            try
            {
                // Register your MVC controllers.
                builder.RegisterControllers(typeof(MvcApplication).Assembly);

                // Register individual types 
                builder.RegisterType<MemoryCacheService>().As<ICache>().SingleInstance();

                // You may want to use different lifetime scopes for your DbContext
                builder.RegisterType<ETailorDbContext>().As<IProductDbContext>().InstancePerLifetimeScope();
                builder.RegisterType<ETailorDbContext>().As<ICategoryDbContext>().InstancePerLifetimeScope(); // Add this line

                builder.RegisterType<ProductsAccessor>().As<IProductsAccessor>().InstancePerLifetimeScope();
                builder.RegisterType<ProductsService>().As<IProducts>().InstancePerLifetimeScope();
                builder.RegisterType<CategoriesAccessor>().As<ICategoriesAccessor>().InstancePerLifetimeScope();
                builder.RegisterType<CategoriesService>().As<ICategories>().InstancePerLifetimeScope();

                // Set the dependency resolver to be Autofac.
                var container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }
            catch (Exception)
            {
                throw; // Rethrow the exception after logging
            }
        }
    }
}
