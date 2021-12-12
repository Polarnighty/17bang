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
    public class CommentService : BaseService
    {
        private CommentRepository commentRepository;
        public CommentService()
        {
            commentRepository = new CommentRepository(context);
        }

        public CommentDto Reply(int id, string content, int? commentId)
        {
            var comment = new Comment { ArticleId = id, Content = content, Commentator = GetCurrentUser(), CommentId = commentId, CommentTime = DateTime.Now };
            commentRepository.Reply(comment);
            return mapper.Map<Comment, CommentDto>(comment);
        }
        public List<CommentDto> GetComments(int id, int page = 1)
        {
            var comments = commentRepository.GetArticleComments(id, page);
            var model = mapper.Map<List<Comment>, List<CommentDto>>(comments);

            //if (article.Appraises.Count != 0)
            //{
            //    model.Appraise.Agree = article.Appraises.Count(a => a.IsAgree == true);
            //    model.Appraise.DisAgree = article.Appraises.Count(a => a.IsAgree == false);
            //    model.Appraise.IsAgree = appraise.IsAgree;
            //}//do nothing

            return model;
        }

        public void Delete(int id)
        {            
            commentRepository.Delete(id, GetCurrentUser().Id);
        }
        public int GetCommentCount(int id)
        {
            return commentRepository.getCommentCount(id);
        }
    }
}
