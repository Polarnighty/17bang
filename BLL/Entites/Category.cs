using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
    public class Category :BaseEntity
    {
        [MaxLength(30)]
        public string Title { get; set; }
        public string Summary { get; set; }
        public IList<Category> Categories { get; set; }
        public int? CategoryId { get; set; }
    }
}
