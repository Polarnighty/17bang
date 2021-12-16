using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SRV.ViewModel
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public bool? Sex { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public string SelfDescription { get; set; }
        public string Icon { get; set; }
        public IList<KeywordModel> Keywords { get; set; }

    }
}
