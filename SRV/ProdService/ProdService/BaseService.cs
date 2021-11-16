using AutoMapper;
using BLL.Entites;
using BLL.Repositories;
using Global;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SRV.ProdService
{
    public class BaseService
    {
        private UserRepository userRepository;

        protected readonly static MapperConfiguration config;
        protected IMapper mapper => config.CreateMapper();

        static BaseService()
        {
            config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Article, NewModel>().ReverseMap();
                    cfg.CreateMap<Article, NewModel>().ReverseMap();
                });
        }
        public BaseService()
        {
            userRepository = new UserRepository(context);
        }

        public static void Commit()
        {
            var objContext = HttpContext.Current.Items[Keys.DbContext];
            if (objContext != null)
            {
                var context = objContext as SqlContext;
                using (var transaction = context.Database.CurrentTransaction)
                {
                    transaction.Commit();
                }
            }
        }
        public static void Rollbasck()
        {
            var objContext = HttpContext.Current.Items[Keys.DbContext];
            if (objContext != null)
            {
                var context = objContext as SqlContext;
                using (var transaction = context.Database.CurrentTransaction)
                {
                    transaction.Rollback();
                }
            }
        }
        protected SqlContext context
        {
            get
            {
                if (HttpContext.Current.Items[Keys.DbContext] == null)
                {
                    var cx = new SqlContext();
                    cx.Database.BeginTransaction();
                    HttpContext.Current.Items[Keys.DbContext] = cx;
                }

                return HttpContext.Current.Items[Keys.DbContext] as SqlContext;
            }
        }
        public User GetCurrentUser(bool userProxy = true)
        {
            var userInfo = HttpContext.Current.Request.Cookies[Keys.User].Values;

            if (userInfo == null)
            {
                return null;
            }

            var hasUserId = int.TryParse(userInfo[Keys.Id], out int CurrentUserId);
            if (!hasUserId)
            {
                throw new ArgumentException("");
            }

            var user = userRepository.Find(CurrentUserId);
            if (user.Password.MD5Encrypt() != userInfo[Keys.Password])
            {
                throw new ArgumentException("");
            }
            //var currentUser = userProxy ? userRepository.LoadProxy(CurrentUserId) : userRepository.Find(CurrentUserId);
            return user;
        }
    }
}
