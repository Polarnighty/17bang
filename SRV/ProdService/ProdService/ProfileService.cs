using BLL.Repositories;
using SRV.ViewModel;
using System.Collections.Generic;
using BLL.Entites;

namespace SRV.ProdService
{
    public class ProfileService : BaseService
    {
        private ProfileRepository profileRepository;
        public ProfileService()
        {
            profileRepository = new ProfileRepository(context);
        }

        public void SaveUserIcon(User user,string icon)
        {
            if (user!=null)
            {                
                profileRepository.SaveUserIcon(user, icon);
            }//else nothing
        }
    }
}
