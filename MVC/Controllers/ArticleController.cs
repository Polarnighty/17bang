using SRV.ViewModel;
using System.Linq;
using System.Web.Mvc;
using SRV.ProdService;
using MVC.Helpers;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleService articleService;
        public ArticleController(ArticleService articleService)
        {
            this.articleService = articleService;
        }
        public ActionResult Index(int id = 1)
        {
            var model = articleService.GetArticles(id, out int count);
            ViewBag.PageCount = count;
            return View(model);
        }
        public ActionResult UserArticle(int userId, int id = 1)
        {
            var model = articleService.GetArticles(id, out int count, userId);
            ViewBag.PageCount = count;
            ViewBag.AuthorId = userId;
            return View(model);
        }
        public ActionResult Single(int id)
        {
            var model = articleService.GetSingleArticle(id);
            return View(model);
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(NewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = articleService.Publish(model);
            return RedirectToAction("Single", new { id = model.Id });
        }
        public ActionResult Edit(NewModel model)
        {
            return View();
        }

        [HttpPost]
        public JsonResult Appraise(int id, bool agree)
        {
            articleService.Appraise(id, agree);
            return null;
        }

        public PartialViewResult Comment(int id)
        {
            var model = articleService.GetComment(id);
            return PartialView(model);
        }

        //[HttpPost]
        //public ActionResult Reply(int id, string )
        //{
        //    var appraise = articleService.Appraise(id, agree);
        //    return Json(appraise, JsonRequestBehavior.AllowGet);
        //}


    }
}