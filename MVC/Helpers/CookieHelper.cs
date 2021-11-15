using Global;
using SRV.ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Helpers
{
    public class CookieHelper
    {
        private static UserService userService = new UserService();

        public static void Delete(string name)
        {
        }

        public static int? GetCurrentUserId()
        {
            var userInfo = HttpContext.Current.Request.Cookies[Keys.User].Values;
            if (userInfo==null)
            {
                return null;
            }

            var hasUserId = int.TryParse(userInfo[Keys.Id], out int CurrentUserId);
            if (!hasUserId)
            {
                throw new ArgumentException("");
            }

            var pwd = userService.GetPwdById(CurrentUserId);
            if (pwd.MD5Encrypt()!=userInfo[Keys.Password])
            {
                throw new ArgumentException("");
            }

            return CurrentUserId;
        }
    }
}