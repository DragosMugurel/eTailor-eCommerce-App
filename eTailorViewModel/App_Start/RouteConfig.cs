using System.Web.Mvc;
using System.Web.Routing;

public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        routes.MapRoute(
            name: "About",
            url: "Home/About",
            defaults: new { controller = "Home", action = "About" }
        );

        routes.MapRoute(
            name: "AdminLogin",
            url: "Admin/{action}/{id}",
            defaults: new { controller = "Admin", action = "Login", id = UrlParameter.Optional }
        );

        routes.MapRoute(
            name: "Account",
            url: "Account/{action}/{id}",
            defaults: new { controller = "Admin", action = "Login", id = UrlParameter.Optional }
        );

        routes.MapRoute(
            name: "AdaugareProdusAdmin",
            url: "Admin/Produs/Adauga",
            new { controller = "Produs", action = "Create" }
        );

        routes.MapRoute(
           name: "Cart",
           url: "Home/Cart",
           defaults: new { controller = "Home", action = "Cart" }
       );

        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
}
