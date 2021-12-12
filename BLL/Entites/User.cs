using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entites
{
    public class User : BaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public User InviterBy { get; set; }
        [MaxLength(4)]
        public string InviterCode { get; set; }
        public IList<Article> Articles { get; set; }
        public IList<Message> Messages { get; set; }
        //public IList<Comment> Comments { get; set; }

        public void Register()
        {

        }
    }
}
