using Global;
using SRV.ProdService;
using SRV.ViewModel;
using System.Web.Mvc;
using System.Web;

namespace MVC.Controllers
{
    public class RegisterController : Controller
    {
        private UserService userService = new UserService();

        [HttpGet]        
        public ActionResult Index()
        {
            if (Request.Cookies[Keys.User]==null)
            {
                Response.Cookies.Add(new HttpCookie(Keys.User));
                var userInfo = Response.Cookies[Keys.User].Values;
                userInfo[Keys.Id] = Keys.Id;
                userInfo[Keys.Password] = Keys.Id;
            }

            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            #region 前端验证
            if (model.InviterByName == null)
            {
                ModelState.AddModelError("model.InviterBy.Name", "* 邀请人不能为空");
            }
            if (model.Name == null)
            {
                ModelState.AddModelError("model.Name", "* 用户名不能为空");
            }
            if (model.Password == null)
            {
                ModelState.AddModelError("model.Name", "* 密码不能为空");
            }
            if (model.InviterCode == null)
            {
                ModelState.AddModelError("model.Name", "* 邀请码不能为空");
            }
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "密码不一致");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            #endregion

            var invitedBy = userService.GetByName(model.InviterByName);

            if (invitedBy == null)
            {
                ModelState.AddModelError("RegisterModel.InviterBy.Name", "* 邀请人不存在");
                return View();
            }
            if (invitedBy.InviterCode != model.InviterCode)
            {
                ModelState.AddModelError("RegisterModel.InviterBy.InviterCode", "* 邀请码错误");
                return View();
            }

            var registerUser = userService.GetByName(model.Name);
            if (registerUser != null)
            {
                ModelState.AddModelError("RegisterModel.Name", "* 用户名重复，请重新输入");
                return View();
            }
            Request.Cookies.Add(new HttpCookie(Keys.User));
            var userInfo = Request.Cookies[Keys.User].Values;
            userInfo[Keys.Id] = Keys.Id;
            userInfo[Keys.Password] = Keys.Id;

            userService.Register(model);

            return Redirect("/Log/On");
        }
    }
}