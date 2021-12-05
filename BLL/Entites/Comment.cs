using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BLL.Entites.Interface;
namespace BLL.Entites
{
    public class Comment : BaseEntity
    {
        public int? CommentId { get; set; }
        public User Commentator { get; set; }
        [MaxLength(100)]
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }
        public IList<Appraise> Appraises { get; set; }
        public IList<Comment> CommentBy { get; set; }
        public Article Article { get; set; }

    }
}
