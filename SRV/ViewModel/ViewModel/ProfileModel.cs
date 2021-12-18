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
        public bool? IsFemale { get; set; }
        public int? BirthYear { get; set; }
        public int? BirthMonth { get; set; }
        public string Constellation { get; set; }
        public string SelfDescription { get; set; }
        public string Icon { get; set; }
        public IList<KeywordModel> Keywords { get; set; }

    }
}
