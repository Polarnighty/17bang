using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRV.ViewModel;
using System.IO;
using MVC.Helpers;
using MVC.Filters;
using SRV.ProdService;

namespace MVC.Controllers
{
    public class ProfileController : Controller
    {
        private ProfileService profileService;

        public ProfileController(ProfileService profileService)
        {
            this.profileService = profileService;
        }
        // GET: Home
        public ActionResult Write()
        {
            return View();
        }
        [HttpPost]
        [NeedLogOn]
        public ActionResult Write(ProfileModel model)
        {
 

            return View();
        }

        public string UserIcon(HttpPostedFileBase icon)
        {

            if (icon.ContentLength > 1024 * 800)
            {
                ModelState.AddModelError("", "文件过大");
            }
            if (!icon.ContentType.StartsWith("image"))
            {
                ModelState.AddModelError("", "上传的不是图片类型");
            }
            if (!ModelState.IsValid)
            {
                return "";
            }

            var Now = DateTime.Now;
            var user = CookieHelper.GetCurrentUserId();

            string urlPath = $@"/Images/{Now.Year}/{Now.Month}/{Now.Day}";
            string urlName = Path.Combine(urlPath, $"{user.Id}{Path.GetExtension(icon.FileName)}");
            if (!Directory.Exists(urlPath))
            {
                Directory.CreateDirectory(urlPath);
            }
            icon.SaveAs(Server.MapPath(urlName));

            profileService.SaveUserIcon(user,urlName);
            return urlName;
        }

    }
}