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
        public static User fg { get; set; }
        public UserFactory(SqlContext context)
        {
            userRepository = new UserRepository(context);
        }
        public void Create()
        {
            fg = new User { Name = "fg", Password = "1234".MD5Encrypt(), InviterCode = "1234" };
            userRepository.Save(fg);
        }
    }
}
