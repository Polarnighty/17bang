using SRV.ViewModel;
using System.Web.Mvc;
using SRV.ProdService;

namespace MVC.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleService articleService;
        private CommentService commentService;

        public ArticleController(ArticleService articleService, CommentService commentService)
        {
            this.articleService = articleService;
            this.commentService = commentService;
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
            model.Comments = commentService.GetComments(id);
            model.Reply = new CommentModel();
            ViewBag.CommentCount = commentService.GetCommentCount(id);
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

        public PartialViewResult Comment(int id, int page = 1)
        {
            var model = commentService.GetComments(id, page);
            return PartialView("Comment/Comments", model);
        }
        public bool DeleteComment(int id)
        {
            return commentService.Delete(id);
        }

        [HttpPost]
        public PartialViewResult Reply(int id, CommentModel Reply)
        {
            var model = commentService.Reply(id, Reply);
            return PartialView("Comment/Reply", model);
        }


    }
}