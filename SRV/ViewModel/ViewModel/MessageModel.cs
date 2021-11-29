using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{
    public class MessageModel
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public string Content { get; set; }
        public SubscriptionType Type { get; set; }
        public int UserId { get; set; }
        public bool HasRead { get; set; }
        public bool Selected { get; set; }
    }

    public enum SubscriptionType
    {
        Refresh,
        Invite
    }

}
