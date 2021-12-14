using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entites
{
    public class Comment : BaseEntity
    {
        public User Commentator { get; set; }
        public int? CommentatorId { get; set; }
        [MaxLength(200)]
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }
        public IList<Appraise> Appraises { get; set; }
        public int? CommentId { get; set; }
        public IList<Comment> CommentBy { get; set; }
        public Article Article { get; set; }
        public int ArticleId { get; set; }

    }
}
