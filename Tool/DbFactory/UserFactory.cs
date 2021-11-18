using BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entites;
using Global;

namespace DbFactory
{
    class UserFactory
    {
        private UserRepository userRepository;
        public UserFactory(SqlContext context)
        {
            userRepository = new UserRepository(context);
        }
        public void Create()
        {
            userRepository.Save(new User { Name = "fg", Password = "1234".MD5Encrypt(), InviterCode = "1234"});
        }
    }
}
