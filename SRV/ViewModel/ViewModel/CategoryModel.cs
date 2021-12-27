using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="* 标题不能为空")]
        public string Title { get; set; }
        public string Summary { get; set; }
        public IList<CategoryModel> Categories { get; set; }
        public Dictionary<int,string> SelectItem { get; set; }
        public int? CategoryId { get; set; }

    }
}
