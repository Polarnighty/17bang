using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRV.ProdService;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Categorys
        private CategoryService categoryService;
        public ActionResult Manage()
        {
            var model = categoryService.GetCategories();
            return View(model);
        }
        public ActionResult NewOrEdit()
        {
            var model = categoryService.GetCategories();
            return View(model);
        }


    }
}