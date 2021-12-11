using System;
using System.Collections.Generic;
using BLL.Entites;
using Global;
using System.Linq;
using System.Data.Entity;

namespace BLL.Repositories
{
    public class AppraiseRepositary : Repository<Appraise>
    {
        public AppraiseRepositary(SqlContext context) : base(context)
        {
        }

        public void Appraise(int id, AppraiseType type, User user, bool agree)
        {
            var appraise = new Appraise();
            switch (type)
            {
                case AppraiseType.Article:
                    appraise = DbSet.Where(a => a.ArticleId == id).SingleOrDefault();
                    if (appraise == null)
                    {
                        DbSet.Add(new Appraise { IsAgree = agree, Appraiser = user, ArticleId = id });
                        context.SaveChanges();
                        return;
                    }
                    break;
                case AppraiseType.Comment:
                    appraise = DbSet.Where(a => a.CommentId == id && a.AppraiserId == user.Id).SingleOrDefault();
                    if (appraise == null)
                    {
                        DbSet.Add(new Appraise { IsAgree = agree, Appraiser = user, CommentId = id });
                        context.SaveChanges();
                        return;
                    }
                    break;
                default:
                    break;
            }

            if (appraise.IsAgree == agree)
            {
                appraise.IsAgree = null;
                context.SaveChanges();
                return;
            }

            appraise.IsAgree = agree;
            context.SaveChanges();
        }
        public Appraise GetAppraise(int id, AppraiseType type, User user)
        {
            var appraise = new Appraise();
            var query = DbSet.AsQueryable<Appraise>();
            if (user != null)
            {
                query = query.Where(a => a.Appraiser.Id == user.Id);
            }
            switch (type)
            {
                case AppraiseType.Article:
                    appraise = query.Where(a => a.ArticleId == id).SingleOrDefault();
                    break;
                case AppraiseType.Comment:
                    appraise = query.Where(a => a.CommentId == id).SingleOrDefault();
                    break;
                default:
                    break;
            }
            return appraise;
        }

        public int GetAppraiseCount(int id, AppraiseType type, bool agree =true)
        {
            switch (type)
            {
                case AppraiseType.Article:
                    return DbSet.Count(a => a.ArticleId == id && a.IsAgree == agree);
                case AppraiseType.Comment:
                    return DbSet.Count(a => a.CommentId == id && a.IsAgree == agree);
                default:
                    break;
            }
            return 0;
        }
    }


}