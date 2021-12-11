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


    }
}
