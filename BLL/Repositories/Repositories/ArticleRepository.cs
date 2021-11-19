using BLL.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace BLL.Repositories
{
    public class ArticleRepository : Repository<Article>
    {
        public ArticleRepository(SqlContext context) : base(context)
        {
        }

        public List<Article> GetArticles(int pageIndex, int? author, int pageSize = 5)
        {
            var query = DbSet.AsQueryable();
            if (author != null)
            {
                //Articles.
                //query = DbSet.Where(a => a.Author.Id == author);
                query = DbSet.Where(a => a.Author.Id == author);
            }
            return query.OrderBy(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .Include(a=>a.Author).ToList();
        }

        public int GetCount(int? authorId = null)
        {
            if (authorId != null)
            {
                return DbSet.Count(a => a.AuthorId == authorId);
            }
            return DbSet.Count();
        }
    }
}
