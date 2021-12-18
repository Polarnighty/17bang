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
        public ProfileModel GetProfile()
        {
            var profile = profileRepository.GetProfile(GetCurrentUser());
            return mapper.Map<Profile, ProfileModel>(profile)?? new ProfileModel { Icon =""};
        }
        public void SaveProfile(ProfileModel model)
        {
            var profile= mapper.Map<ProfileModel, Profile>(model);
            profile.User = GetCurrentUser();
            profile.UserId = profile.User.Id;
            profileRepository.SaveProfile(profile);
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
