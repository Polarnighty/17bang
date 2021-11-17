using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Filters
{
    public class NeedLogOn : IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.Cookies==null)
            {
                var refer = filterContext.HttpContext.Request.UrlReferrer.ToString();
                HttpContext.Current.Response.Redirect(refer);
            }

        }

    }
}