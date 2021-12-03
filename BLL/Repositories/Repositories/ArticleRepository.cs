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
                query = DbSet.Where(a => a.Author.Id == author);
            }
            return query.OrderBy(a => a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .Include(au => au.Author)
                .ToList();
        }

        public int GetCount(int? authorId = null)
        {
            if (authorId != null)
            {
                return DbSet.Count(a => a.AuthorId == authorId);
            }
            return DbSet.Count();
        }
        public Article GetSingleArticle(int id)
        {
            return DbSet.Where(a => a.Id == id)
                .Include(a => a.Appraises)
                //.Include(a => a.Comments)
                .SingleOrDefault();
        }
        public Article GetNextArticle(int id)
        {
            return DbSet.Where(a => a.Id > id).FirstOrDefault();
        }
        public Article GetPrevArticle(int id)
        {
            return DbSet.Where(a => a.Id < id).OrderByDescending(a => a.Id).FirstOrDefault();
        }

        public Article Appraise(int id, User user, bool agree)
        {
            var article = DbSet.Where(a => a.Id == id).Include(a => a.Appraises).SingleOrDefault();
            if (agree)
            {
                article.Agree(user);
            }
            else
            {
                article.DisAgree(user);
            }
            context.SaveChanges();
            return article;
        }

    }
}
