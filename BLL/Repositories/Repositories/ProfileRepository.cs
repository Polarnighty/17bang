using BLL.Entites;
using System;
using System.Collections.Generic;
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


    }
}
