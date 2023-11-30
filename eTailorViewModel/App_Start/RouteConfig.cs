using System.Web.Mvc;
using System.Web.Routing;

public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        // Default route for Home controller
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
        // Custom route for Create action in Produs controller
        routes.MapRoute(
            name: "AdaugareProdusAdmin",
            url: "Admin/Produs/Adauga",
            new { controller = "Produs", action = "Create" }
        );

    }
}
