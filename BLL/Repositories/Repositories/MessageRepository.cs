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
            return DbSet.OrderByDescending(m => m.CreateTime).OrderBy(m => m.HasRead).Where(m => m.UserId == userId ).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public void HasRead(List<Message> messages)
        {
            DbSet.AddRange(messages);
        }
        public void Remove(List<Message> messages)
        {
            DbSet.RemoveRange(messages);
        }

        public int GetCount(int userId)
        {
            return DbSet.Count(m=> m.UserId == userId);
        }

    }
}
