using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entites
{
    public class Profile:BaseEntity
    {
        public bool? Sex { get; set; }
        [MaxLength(4)]
        public int? Year { get; set; }
        [MaxLength(2)]
        public int? Month { get; set; }
        [MaxLength(255)]
        public string SelfDescription { get; set; }
        public IList<Keyword> Keywords { get; set; }
        [MaxLength(80)]
        public string Icon { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public void upload()
        {
        }
    }
}
