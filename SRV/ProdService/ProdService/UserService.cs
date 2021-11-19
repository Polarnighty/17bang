using BLL.Entites;
using BLL.Repositories;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ProdService
{
    public class UserService : BaseService
    {
        private UserRepository userRepository = new UserRepository(new SqlContext());
        public int? Register(UserModel model)
        {            
            var NewUser=mapper.Map<UserModel, User>(model);
            NewUser.InviterBy = userRepository.GetByName(model.InviterByName);
            return userRepository.Save(NewUser);
        }
        //public int LogOn(LogOnModel model)
        //{            
        //    var user=mapper.Map<LogOnModel, User>(model);
        //    return userRepository.Save(user);
        //}

        public UserModel GetByName(string name)
        {
            var user = userRepository.GetByName(name);
            return mapper.Map<User,UserModel>(user);
        }
        public string GetPwdById(int id)
        {
            var password = userRepository.GetPwdById(id);
            return password;
        }
    }
}
