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
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel model)
        {
            #region 前端验证        
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "密码不一致");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            #endregion

            var invitedBy = userService.GetByName(model.InviterByName);

            if (invitedBy == null)
            {
                ModelState.AddModelError("InviterByName", "* 邀请人不存在");
                return View(model);
            }
            if (invitedBy.InviterCode != model.InviterCode)
            {
                ModelState.AddModelError("InviterCode", "* 邀请码错误");
                return View(model);
            }

            var registerUser = userService.GetByName(model.Name);
            if (registerUser != null)
            {
                ModelState.AddModelError("Name", "* 用户名重复，请重新输入");
                return View(model);
            }


            model.Password = model.Password.MD5Encrypt();
            userService.Register(model);

            return Redirect("/Log/On");
        }
    }
}