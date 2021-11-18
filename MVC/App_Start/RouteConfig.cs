using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Article",
                url: "{controller}/Page-{id}",
                defaults: new { controller = "Article", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ArticleSingle",
                url: "{controller}/{id}",
                defaults: new { controller = "Article", action = "Single" }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
