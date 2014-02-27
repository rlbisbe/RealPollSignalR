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
               name: "Create",
               url: "New",
               defaults: new { controller = "Question", action = "New" }
           );

            routes.MapRoute(
              name: "Email",
              url: "Email",
              defaults: new { controller = "Question", action = "Email" }
          );

            routes.MapRoute(
               name: "Question",
               url: "Question/{id}",
               defaults: new { controller = "Question", action = "Result" }
           );

            routes.MapRoute(
               name: "Vote",
               url: "{id}",
               defaults: new { controller = "Question", action = "Vote" }
           );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
