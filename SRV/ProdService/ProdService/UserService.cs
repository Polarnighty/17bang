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
        public int Register(UserModel model)
        {
            var NewUser = new User() { Name = model.Name, Password = model.Password, InviterCode = model.InviterCode };
            return userRepository.Save(NewUser);
        }

        public UserModel GetByName(string name)
        {
            var user = userRepository.GetByName(name);
            return new UserModel
            {
                Id = user.Id,
                Password = user.Password,
                Name = user.Name,
                InviterCode = user.InviterCode,
                InviterBy = user.InviterBy.Id.ToString()
            };
        }
        public string GetPwdById(int id)
        {
            var password = userRepository.GetPwdById(id);
            return password;

            //return new UserModel
            //{
            //    Id = user.Id,
            //    Password = user.Password,
            //    Name = user.Name,
            //    InviterCode = user.InviterCode,
            //    InviterBy = user.InviterBy.Id.ToString()
            //};
        }
    }
}
