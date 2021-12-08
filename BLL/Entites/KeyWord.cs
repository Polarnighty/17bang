using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
    public class KeyWord :BaseEntity
    {
        [MaxLength(10)]
        public string Content { get; set; }
        public short Level { get; set; }
        public List<KeyWord> KeyWords { get; set; }
        public int? KeyWordId { get; set; }
    }
}
