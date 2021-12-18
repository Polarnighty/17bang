using BLL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class ProfileRepository : Repository<Profile>
    {
        public ProfileRepository(SqlContext context) : base(context)
        {
        }

        public void SaveUserIcon(User user, string icon)
        {
            var profile = DbSet.Where(p => p.UserId == user.Id).SingleOrDefault();
            if (profile!=null)
            {
                profile.Icon = icon;
            }
            else
            {
                DbSet.Add(new Profile { UserId = user.Id, Icon = icon });
            }
            context.SaveChanges();
        }

        public Profile GetProfile(User user)
        {
            return DbSet.Where(p => p.UserId == user.Id).SingleOrDefault();
        }
        public void SaveProfile(Profile profile)
        {
            var oldProfile = DbSet.Where(p => p.UserId == profile.User.Id).SingleOrDefault();
            if (oldProfile!=null)
            {
                oldProfile.IsFemale = profile.IsFemale;
                oldProfile.BirthYear = profile.BirthYear;
                oldProfile.BirthMonth = profile.BirthMonth;
                oldProfile.Constellation = profile.Constellation;
                oldProfile.SelfDescription = profile.SelfDescription;

                //
                //profile.Icon = oldProfile.Icon;
                //profile.Id = oldProfile.Id;
                //DbSet.Update(profile);
            }
            else
            {
                DbSet.Add(profile);
            }
            context.SaveChanges();
        }

    }
}
