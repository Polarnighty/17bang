using Global;
using SRV.ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Filters
{
    public class ContextPerRequest : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction)
            {
                if (filterContext.Exception == null)
                {
                    BaseService.Commit();
                }
                else
                {
                    BaseService.Rollbasck();
                }
            }

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //throw new NotImplementedException();
        }
    }
}