using Global;
using SRV.ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Filters
{
    public class LogOn : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //if (filterContext.HttpContext.Request.RawUrl=="/")
            //{
            //    return;
            //}
            if (filterContext.HttpContext.Request.Cookies[Keys.User]!=null)
            {
                var user = new BaseService().GetCurrentUser();
                filterContext.Controller.ViewBag.UserName = user.Name;
                return;
            }
            //filterContext.HttpContext.Response.Redirect("/");

        }
    }
}