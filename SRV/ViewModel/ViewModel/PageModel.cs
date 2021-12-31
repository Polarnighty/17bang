using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{
    public class PageModel
    {
        public int CurrentPage { get; set; } = 1;
        public int TotalPage { get; set; }
    }
}
