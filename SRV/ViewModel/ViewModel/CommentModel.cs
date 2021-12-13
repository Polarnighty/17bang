using System;
using System.Collections.Generic;
using System.Linq;

namespace SRV.ViewModel
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int? CommentId { get; set; }
        public int CommentatorId { get; set; }
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }
        public List<CommentModel> CommentBy { get; set; }
        public bool? IsAgree { get; set; }
        public int AgreeCount { get; set; }
        public int DisAgreeCount { get; set; }
        public int ArticleId { get; set; }
        public int? Floor { get; set; }

    }
}
