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
                var keyword = DbSet.Where(k => k.Content == item.Content).SingleOrDefault();
                if (keyword != null)
                {
                    article.Keywords.Add(keyword);
                    context.Set<Article>().Add(article);
                }
                else
                {
                    item.Articles.Add(article);
                    DbSet.Add(item);
                }
            }
            context.SaveChanges();
        }

    }
}
