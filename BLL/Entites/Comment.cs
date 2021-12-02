using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entites
{
    public class Comment :BaseEntity
    {
        public User Author { get; set; }
        [MaxLength(100)]
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }
        public IList<Appraise> Appraises { get; set; }
        public IList<Comment> Comments { get; set; }

    }
}
