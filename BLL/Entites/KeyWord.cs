using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entites
{
    public class Keyword :BaseEntity
    {
        [MaxLength(15)]
        public string Content { get; set; }
        public short? Level { get; set; }
        public IList<Keyword> Keywords { get; set; }
        public IList<Article> Articles { get; set; }
    }
}
