using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRV.ProdService;
namespace MVC.Controllers
{
    public class RemoteValidateController : Controller
    {
        private UserService userService;
        
        public RemoteValidateController(UserService userService)
        {
            this.userService = userService;
        }
        public ActionResult UserNameValidate(string name)
        {
            bool NotExists = userService.GetByName(name) == null;
            return Json(NotExists, JsonRequestBehavior.AllowGet);
        }
    }
}