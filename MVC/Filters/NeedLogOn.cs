using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Filters
{
    public class NeedLogOnAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies[Keys.User] == null)
            {
                //var refer = filterContext.HttpContext.Request.UrlReferrer.ToString();
                HttpContext.Current.Response.Redirect("/Log/On");
                filterContext.Result = new EmptyResult();
            }
        }

    }
}