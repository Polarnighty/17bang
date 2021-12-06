using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public PartialViewResult Comment(int id)
        {
            //var model = articleService.GetComment(id);
            return PartialView();
        }


    }
}