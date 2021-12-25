using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRV.ProdService;
using SRV.ViewModel;
namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Categorys
        private CategoryService categoryService;
        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public ActionResult Manage()
        {
            var model = categoryService.GetCategories();
            return View();
        }
        public ActionResult NewOrEdit(CategoryModel model)
        {
            categoryService.NewOrEdit(model);
            return RedirectToAction("Manage");
        }


    }
}