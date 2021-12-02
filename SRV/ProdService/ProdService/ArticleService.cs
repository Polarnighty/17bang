using BLL.Entites;
using BLL.Entites.EnityDto;
using BLL.Repositories;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SRV.ProdService
{
    public class ArticleService : BaseService
    {
        private ArticleRepository articleRepository;
        public ArticleService()
        {
            articleRepository = new ArticleRepository(context);
        }
        public int? Publish(NewModel model)
        {
            var user = GetCurrentUser();
            if (user == null)
            {
                return null;
                //throw new ArgumentException("");
            }

            var article = new Article { Body = model.Body, Title = model.Title, PublishDateTime = DateTime.Now, Author = user, AuthorId = user.Id };
            return articleRepository.Save(article);
        }

        public IList<ArticleModel> GetArticles(int pageIndex, out int count, int? authorId = null, int pageSize = 5)
        {
            var articles = articleRepository.GetArticles(pageIndex, authorId);
            count = articleRepository.GetCount(authorId);
            count = count % 5 != 0 ? count / pageSize + 1 : count / pageSize;
            var articleModels = new List<ArticleModel>();
            foreach (var item in articles)
            {
                var model = mapper.Map<Article, ArticleModel>(item);
                model.AuthorName = item.Author.Name;

                articleModels.Add(model);
            }
            return articleModels;
        }

        public SingleModel GetSingleArticle(int id)
        {
            var article = articleRepository.GetSingleArticle(id);

            var Next = articleRepository.GetNextArticle(id);
            var Prev = articleRepository.GetPrevArticle(id);
            var model = mapper.Map<Article, SingleModel>(article);

            model.NextId = Next?.Id;
            model.NextTitle = Next?.Title;
            model.PreviousTitle = Prev?.Title;
            model.PreviousId = Prev?.Id;

            model.Appraise = new AppraiseDto { Agree = 0, DisAgree = 0 };

            if (article.Appraises.Count != 0)
            {
                model.Appraise.Agree = article.Appraises.Count(a => a.Agree == true);
                model.Appraise.DisAgree = article.Appraises.Count(a => a.Agree == false);
            }//do nothing

            return model;
        }

        public AppraiseDto Appraise(int id, bool agree)
        {
            var article = articleRepository.Appraise(id, GetCurrentUser(), agree);

            return new AppraiseDto
            {
                Agree = article.Appraises.Count(a => a.Agree == true),
                DisAgree = article.Appraises.Count(a => a.Agree == false)
            };

        }

    }
}
