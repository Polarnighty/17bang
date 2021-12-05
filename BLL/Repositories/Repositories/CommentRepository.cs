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

        public List<Comment> GetArticleComments(int articleId)
        {
            return DbSet.Where(c => c.Article.Id == articleId).Take(1).Include(c => c.CommentBy).ToList();
        }
   
    }
}
