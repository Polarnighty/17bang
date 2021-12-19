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

        public void SaveKeywords<T>(T t, IList<Keyword> keywords)
        {
            switch (t)
            {
                case Article article:
                    SaveArticle(article, keywords);
                    break;
                case Profile profile:
                    SaveProfile(profile, keywords);
                    break;
                default:
                    break;
            }
            context.SaveChanges();
        }

        public void SaveArticle(Article article, IList<Keyword> keywords)
        {
            foreach (var item in keywords)
            {
                var keyword = DbSet.Where(k => k.Content == item.Content).SingleOrDefault();
                if (keyword != null)
                {
                    article.Keywords.Add(item);
                    context.Set<Article>().Add(article);
                }
                else
                {
                    item.Articles = new List<Article> { article };
                    DbSet.Add(item);
                }
            }
        }
        public void SaveProfile(Profile profile, IList<Keyword> keywords)
        {
            foreach (var item in keywords)
            {
                var keyword = DbSet.Where(k => k.Content == item.Content).SingleOrDefault();

                if (keyword != null)
                {
                    profile.Keywords.Add(item);
                    context.Set<Profile>().Add(profile);
                }
                else
                {
                    item.Profiles= new List<Profile> { profile }; ;
                    DbSet.Add(item);
                }
            }
        }

    }
}
