using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CategoryModel> Categories { get; set; }
        public int CategoryId { get; set; }

    }
}
