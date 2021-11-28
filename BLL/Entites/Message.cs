using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
    public class Message : BaseEntity
    {
        public DateTime CreateTime { get; set; }
        [MaxLength(50)]
        public string Content { get; set; }
        public SubscriptionType Type { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public bool HasRead { get; set; }
    }

    public enum SubscriptionType
    {
        Refresh,
        Invite
    }
}
