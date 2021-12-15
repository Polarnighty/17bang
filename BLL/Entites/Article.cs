using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entites
{
    public class Article : BaseEntity
    {
        [MaxLength(20)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Summary { get; set; }
        [Column(TypeName = "ntext")]
        public string Body { get; set; }
        public DateTime PublishDateTime { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set; }
        public List<Appraise> Appraises { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<Keyword> Keywords { get; set; }
    }
}
