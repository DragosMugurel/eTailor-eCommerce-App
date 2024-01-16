

using System.Web.Http;
using System.Web.Http.Cors;

namespace PresentationLayer_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes   
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var cors = new EnableCorsAttribute("https://localhost:44325", "*", "*");
            config.EnableCors(cors);
        }
    }
}
