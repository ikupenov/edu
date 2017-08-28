using System.Web.Mvc;
using System.Web.Routing;

namespace SchoolWebsite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{lang}/{controller}/{action}/{id}",
                constraints: new { lang = @"(\w{2})|(\w{2}-\w{2})" },   // en or en-US
                defaults: new { lang = "bg", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
