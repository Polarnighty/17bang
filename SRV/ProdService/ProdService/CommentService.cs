using BLL.Entites;
using BLL.Repositories;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Global;
using System.Web;

namespace SRV.ProdService
{
    public class CommentService : BaseService
    {
        private CommentRepository commentRepository;
        public CommentService()
        {
            commentRepository = new CommentRepository(context);
        }

        public CommentModel Reply(int id, CommentModel model)
        {
            model.CommentTime = DateTime.Now;
            model.CommentatorId = GetCurrentUser().Id;
            model.ArticleId = id;
            commentRepository.Reply(mapper.Map<CommentModel, Comment>(model));
            return model;
        }
        public List<CommentModel> GetComments(int articleId, int page = 1)
        {
            var comments = commentRepository.GetArticleComments(articleId, page);
            var model = mapper.Map<List<Comment>, List<CommentModel>>(comments);

            //if (article.Appraises.Count != 0)
            //{
            //    model.Appraise.Agree = article.Appraises.Count(a => a.IsAgree == true);
            //    model.Appraise.DisAgree = article.Appraises.Count(a => a.IsAgree == false);
            //    model.Appraise.IsAgree = appraise.IsAgree;
            //}//do nothing

            return model;
        }

        public bool Delete(int id)
        {            
            return commentRepository.Delete(id, GetCurrentUser().Id);
        }
        public int GetCommentCount(int id)
        {
            var CommentCount= commentRepository.getCommentCount(id); 
            if (CommentCount%5>0)
            {
                return (CommentCount / 5) + 1;
            }
            return CommentCount/5;
        }
    }
}
