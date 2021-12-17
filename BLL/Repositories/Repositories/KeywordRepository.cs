using BLL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class KeywordRepository : Repository<Keyword>
    {
        public KeywordRepository(SqlContext context) : base(context)
        {
        }

        public void SaveKeywords(Article article, IList<Keyword> keywords)
        {
            foreach (var item in keywords)
            {
                var kid = DbSet.Where(k => k.Content == item.Content).Include(k => k.Articles)
                                .Select(k => k.Id).SingleOrDefault();
                if (kid != 0)
                {
                    article.Keywords.Add(LoadProxy(kid));
                    context.Set<Article>().Add(article);
                }
                else
                {
                    item.Articles = new List<Article> { article };
                    DbSet.Add(item);
                }
            }
            context.SaveChanges();
        }

    }
}
