using BLL.Entites;
using BLL.Repositories;
using SRV.ViewModel;
using SRV.ViewModel.EnityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using Global;
using System.Web;

namespace SRV.ProdService
{
    public class ArticleService : BaseService
    {
        private ArticleRepository articleRepository;
        private CommentRepository commentRepository;
        private AppraiseRepositary appraiseRepositary;
        public ArticleService()
        {
            articleRepository = new ArticleRepository(context);
            commentRepository = new CommentRepository(context);
            appraiseRepositary = new AppraiseRepositary(context);
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


            var appraise = new Appraise();
            if (HttpContext.Current.Request.Cookies[Keys.User]?.Values != null)
            {
                appraise = appraiseRepositary.GetAppraise(id, AppraiseType.Article, GetCurrentUser());
            }
            else
            {
                appraise = appraiseRepositary.GetAppraise(id, AppraiseType.Article);
            }
            model.Appraise = new AppraiseDto { Agree = 0, DisAgree = 0 };
            if (article.Appraises.Count != 0)
            {
                model.Appraise.Agree = article.Appraises.Count(a => a.IsAgree == true);
                model.Appraise.DisAgree = article.Appraises.Count(a => a.IsAgree == false);
                model.Appraise.IsAgree = appraise.IsAgree;
            }//do nothing

            //var comments = commentRepository.GetArticleComments(id);
            //model.Comments = mapper.Map<List<Comment>, List<CommentDto>>(comments);

            return model;
        }

        public void Appraise(int id, bool agree)
        {
            appraiseRepositary.Appraise(id, AppraiseType.Article,GetCurrentUser(), agree);
        }

        public List<CommentDto> GetComment(int id)
        {
            var comments = commentRepository.GetArticleComments(id);
            return mapper.Map<List<Comment>,List<CommentDto>>(comments);
        }


    }
}
