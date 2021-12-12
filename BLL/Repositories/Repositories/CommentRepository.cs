using BLL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class CommentRepository : Repository<Comment>
    {
        public CommentRepository(SqlContext context) : base(context)
        {
        }

        public List<Comment> GetArticleComments(int articleId, int page, int pageIndex = 5)
        {
            return DbSet.Where(c => c.Article.Id == articleId && c.CommentId == null).OrderBy(c=>c.Id).Skip((page - 1) * pageIndex).Take(pageIndex)
                .Include(c => c.CommentBy)
                .Include(c => c.Appraises)
                .ToList();
        }

        public int? Reply(Comment comment)
        {
            DbSet.Add(comment);
            context.SaveChanges();
            return comment.Id;
        }

        public int getCommentCount(int id)
        {
            return DbSet.Count(c => c.ArticleId == id && c.CommentId==null);
        }
    }
}
