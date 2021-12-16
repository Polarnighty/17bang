using BLL.Repositories;
using SRV.ViewModel;
using System.Collections.Generic;
using BLL.Entites;

namespace SRV.ProdService
{
    public class ProfileService : BaseService
    {
        private MessageRepository messageRepository;
        public ProfileService()
        {
            messageRepository = new MessageRepository(context);
        }


    }
}
