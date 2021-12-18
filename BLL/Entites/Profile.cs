using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.Entites
{
    public class Profile : BaseEntity
    {
        public bool? IsFemale { get; set; }
        public int? BirthYear { get; set; }
        public int? BirthMonth { get; set; }
        public string Constellation { get; set; }

        [MaxLength(255)]
        public string SelfDescription { get; set; }
        public IList<Keyword> Keywords { get; set; }
        [MaxLength(80)]
        public string Icon { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
