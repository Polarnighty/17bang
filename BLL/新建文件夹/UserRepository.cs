using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : Repository<User>
    {
        public User getByName(string name)
        {
            return context.Entites.Where(u => u.UserName == name).SingleOrDefault();
        }

    }
}
