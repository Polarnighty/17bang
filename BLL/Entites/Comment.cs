using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
    public class Comment
    {
        public User Author { get; set; }
        [MaxLength(100)]
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }
    }
}
