using BLL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(SqlContext context) : base(context)
        {
        }

        public User GetByName(string name)
        {
            return DbSet.Where(u => u.Name == name).SingleOrDefault();
        }
        public string GetPwdById(int Id)
        {
            return DbSet.Where(u => u.Id == Id).SingleOrDefault().Password;
        }

    }
}
