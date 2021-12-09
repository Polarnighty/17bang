using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entites
{
    public class KeyWord :BaseEntity
    {
        [MaxLength(15)]
        public string Content { get; set; }
        public short Level { get; set; }
        public List<KeyWord> KeyWords { get; set; }
        public int? KeyWordId { get; set; }
    }
}
