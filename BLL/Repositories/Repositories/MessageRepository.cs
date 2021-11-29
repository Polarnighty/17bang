using BLL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(SqlContext context) : base(context)
        {
        }

        public List<Message> GetMessages(int pageIndex, int userId, int pageSize = 10)
        {
            return DbSet.OrderBy(m=>m.HasRead).ThenByDescending(m=>m.Id).Where(m => m.UserId == userId).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public void HasRead(int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                var message = LoadProxy(ids[i]);
                message.HasRead = true;
            }
            context.SaveChanges();
        }
        public void Remove(List<Message> messages)
        {
            DbSet.RemoveRange(messages.AsEnumerable());
            context.SaveChanges();
        }

        public int GetCount(int userId)
        {
            var count = DbSet.Count(m => m.UserId == userId);
            return count % 10 == 0 ? count / 10  : count / 10+1;
        }

    }
}
