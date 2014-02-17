using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RealPollSignalR
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "Home", action = "About" }
            );

            routes.MapRoute(
                name: "Generate",
                url: "Generate/",
                defaults: new { controller = "Home", action = "Generate" }
            );

            routes.MapRoute(
                name: "Results",
                url: "Results/{id}",
                defaults: new { controller = "Home", action = "Results" }
            );

            routes.MapRoute(
                name: "Vote",
                url: "{id}",
                defaults: new { controller = "Home", action = "Vote" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
