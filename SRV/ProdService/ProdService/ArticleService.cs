using BLL.Entites;
using BLL.Repositories;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ProdService
{
    public class ArticleService : BaseService
    {
        private ArticleRepository articleRepository;
        public ArticleService()
        {
            articleRepository = new ArticleRepository(context);
        }
        public int? Publish(ArticleModel model)
        {
            var user = GetCurrentUser();
            if (user == null)
            {
                return null;
                //throw new ArgumentException("");
            }
            var article = new Article { Body = model.Body, Title = model.Title, PublishDateTime = model.PublishDateTime, Author = user };
            return articleRepository.Save(article);
        }
    }
}
