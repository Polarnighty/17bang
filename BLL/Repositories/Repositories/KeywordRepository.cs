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

        public List<Keyword> GetProfileKeywords(int? pid = null)
        {
            if (pid != null)
            {
                return DbSet.Where(k => k.KeywordId == pid).ToList();
            }
            else
            {
                return DbSet.Where(k => k.Level == 1).ToList();
            }
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
            var oldArticle = context.Set<Article>().Where(p => p.Id == article.Id)
                           .Include(p => p.Keywords).SingleOrDefault();
            //删除全部(可优化[比较后相同的不操作,最后删除])
            oldArticle.Keywords.ToList().ForEach(k => oldArticle.Keywords.Remove(k));

            foreach (var item in keywords)
            {
                var keyword = DbSet.Where(k => k.Content == item.Content).SingleOrDefault();
                if (keyword != null)
                {
                    DbSet.Attach(keyword);
                    keyword.Articles = new List<Article> { article };
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
            var oldProfile = context.Set<Profile>().Where(p => p.Id == profile.Id)
                                                    .Include(p=>p.Keywords).SingleOrDefault();
            //删除全部(可优化[比较后相同的不操作,最后删除])            
            profile.Keywords.ToList().ForEach(k => {
                context.Entry(k).State = EntityState.Deleted;
            });

            foreach (var item in keywords)
            {
                var keyword = DbSet.Where(k => k.Content == item.Content).SingleOrDefault();
                if (keyword != null)
                {
                    //更新方法一
                    //context.Set<Profile>().Attach(profile);
                    //profile.Keywords.Add(item);
                    //Update(profile);
                    //更新方法二
                    DbSet.Attach(keyword);
                    keyword.Profiles = new List<Profile> { profile };
                }
                else
                {
                    item.Profiles = new List<Profile> { profile };
                    DbSet.Add(item);
                }
            }
        }

    }
}
