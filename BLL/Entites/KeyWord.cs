using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entites
{
    public class Keyword :BaseEntity
    {
        [MaxLength(15)]
        public string Content { get; set; }
        public short? Level { get; set; }
        public List<Keyword> Keywords { get; set; }
        public int? ArticleId { get; set; }
    }
}
