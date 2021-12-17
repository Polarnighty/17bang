using Global;
using SRV.ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Entites;
namespace MVC.Helpers
{
    public class CookieHelper
    {
        private static BaseService baseService = new BaseService();

        public static void Delete(string name)
        {
        }

        public static User GetCurrentUserId()
        {
            return baseService.GetCurrentUser();
        }

    }
}