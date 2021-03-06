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
                name: "UserArticle",
                url: "{controller}/User-{userId}/{page}",// Article/User-1/Page-1
                defaults: new { controller = "Article", action = "UserArticle", page = UrlParameter.Optional },
                constraints: new { page = @"\d*", userId = @"\d*" }    //只能是数字
            );

            routes.MapRoute(
                name: "ArticleCategory",
                url: "{controller}/Category-{categoryId}/{page}",// Article/User-1/Page-1
                defaults: new { controller = "Article", action = "ArticleCategory" },
                constraints: new { page = @"\d*", categoryId = @"\d*" }    //只能是数字
            );

            routes.MapRoute(
                name: "Pagination",
                url: "{controller}/Page-{page}",
                defaults: new { controller = "Article", action = "Index", page = UrlParameter.Optional },
                constraints: new { id = @"\d*" }    //只能是数字
            );
            
            routes.MapRoute(
                name: "ArticleSingle",
                url: "Article/{id}",
                defaults: new { controller = "Article", action = "Single" },
                constraints: new { id = @"\d*" }    //只能是数字
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
