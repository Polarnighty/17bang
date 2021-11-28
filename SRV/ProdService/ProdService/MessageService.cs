using BLL.Repositories;
using SRV.ViewModel;
using System.Collections.Generic;
using BLL.Entites;

namespace SRV.ProdService
{
    public class MessageService : BaseService
    {
        private MessageRepository messageRepository;
        public MessageService()
        {
            messageRepository = new MessageRepository(context);
        }

        public List<MessageModel> GetMeesages(int index)
        {
            var userId = GetCurrentUser().Id;
            var messages = messageRepository.GetMessages(index, userId);
            return mapper.Map<List<Message>, List<MessageModel>>(messages);
        }

        public void HasRead(List<MessageModel> models)
        {

            messageRepository.HasRead(mapper.Map<List<MessageModel>, List<Message>>(models));
        }
        public void Remove(List<MessageModel> models)
        {

            messageRepository.Remove(mapper.Map<List<MessageModel>, List<Message>>(models));
        }

        public int GetCount()
        {
            var userId = GetCurrentUser().Id;
            return messageRepository.GetCount(userId);
        }


    }
}
