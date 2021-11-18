using BLL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class ArticleRepository : Repository<Article>
    {
        public ArticleRepository(SqlContext context) : base(context)
        {
        }

        public List<Article> GetArticles(int pageIndex, int pageSize=5,string author=null)
        {
            var query = DbSet.AsQueryable();
            if (author != null)
            {
                query = query.Where(a => a.Author.Name == author);
            }
            return query.OrderBy(a=>a.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}
