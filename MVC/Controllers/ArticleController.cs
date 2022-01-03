using SRV.ViewModel;
using System.Web.Mvc;
using SRV.ProdService;
using MVC.Filters;

namespace MVC.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleService articleService;
        private CommentService commentService;
        private KeywordService keywordService;

        public ArticleController(ArticleService articleService, CommentService commentService, KeywordService keywordService)
        {
            this.articleService = articleService;
            this.commentService = commentService;
            this.keywordService = keywordService;
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
            ViewBag.TotalPage = commentService.GetCommentCount(id);
            ViewBag.ActionName = "Comment";
            return View(model);
        }
        [NeedLogOn]
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

            var article = articleService.Publish(model);
            keywordService.SaveKeywords(article, model.Keywords);
            return RedirectToAction("Single", new { id = article.Id });
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
        [ValidateInput(false)]
        public PartialViewResult Comment(int id, int page = 1)
        {
            var model = commentService.GetComments(id, page);
            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = commentService.GetCommentCount(id);
            ViewBag.ActionName = "Comment";
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