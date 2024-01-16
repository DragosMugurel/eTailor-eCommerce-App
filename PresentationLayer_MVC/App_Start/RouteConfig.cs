using System.Web.Mvc;
using System.Web.Routing;

namespace PresentationLayer_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route for the Edit
            routes.MapRoute(
                name: "Edit",
                url: "Products/Edit/{id}",
                defaults: new { controller = "Products", action = "Edit", id = UrlParameter.Optional }
            );

            // Default route for the Home controller
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            // Route for the Products controller
            routes.MapRoute(
                name: "Products",
                url: "Products/{action}/{id}",
                defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
