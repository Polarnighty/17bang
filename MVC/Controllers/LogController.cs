using Global;
using SRV.ProdService;
using SRV.ViewModel;
using System.Web.Mvc;
using System.Web;
using System;

namespace MVC.Controllers
{
    public class LogController : Controller
    {
        private UserService userService = new UserService();

        private static string Refer { get; set; }
        public ActionResult On()
        {
            if (Refer != Request.Url.ToString())
            {
                Refer = Request.UrlReferrer.ToString();
            }

            return View();
        }

        public ActionResult Off()
        {
            Response.Cookies.Add(new HttpCookie(Keys.User) { Expires = DateTime.Now.AddDays(-1) });
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public ActionResult On(LogOnModel model)
        {
            var user = userService.GetByName(model.Name);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (user==null)
            {
                ModelState.AddModelError("Name", "* 用户不存在");
                return View(model);
            }
            if (user.Password!=model.Password.MD5Encrypt())
            {
                ModelState.AddModelError("Password", "* 密码错误");
                return View(model);
            }

            var userInfo = new HttpCookie(Keys.User);
            userInfo[Keys.Id] = user.Id.ToString();
            userInfo[Keys.Password] = model.Password.MD5Encrypt();
            Response.Cookies.Add(userInfo);

            if (model.RememberMe)
            {
                userInfo.Expires = DateTime.Now.AddDays(90);
            }

            return Redirect(Refer);
        }


    }
}