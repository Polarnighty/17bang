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
    class MessageFactory 
    {
        private MessageRepository messageRepository;
        public MessageFactory (SqlContext context)
        {
            messageRepository = new MessageRepository(context);
        }
        public void Create()
        {
            var messages = new List<Message>();
            for (int i = 0; i < 30; i++)
            {
                var message = new Message
                {
                    UserId =1,
                    Content = $"你好，这是第{i}条测试数据",
                    CreateTime = DateTime.Now.AddDays(-i)
                };
                message.HasRead = i % 2 == 0 ? true : false;
                messages.Add(message);
            }
            messageRepository.RangeSave(messages);
        }
    }
}
