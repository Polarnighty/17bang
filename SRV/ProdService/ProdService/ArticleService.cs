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

        public IList<ArticleModel> GetArticles(int pageIndex, out int count, int pageSize = 5, string author = null)
        {
            var articles =articleRepository.GetArticles(pageIndex);
            count = articleRepository.GetCount();
            count= count % 5 != 0 ? count/pageSize + 1 : count/pageSize;
            var articleModels = new List<ArticleModel>();
            foreach (var item in articles)
            {
                var model=mapper.Map<Article, ArticleModel>(item);
                //model.AuthorName = item.Author.Name;
                articleModels.Add(model);
            }
            return articleModels;
        }

        public SingleModel GetArticleById(int id)
        {
            var article = articleRepository.Find(id);
            return mapper.Map<Article, SingleModel>(article);
        }
    }
}
