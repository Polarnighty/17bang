using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites
{
    public class User : BaseEntity
    {
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public User InviterBy { get; set; }
        [MaxLength(4)]
        public string InviterCode { get; set; }
        public IList<Article> Articles { get; set; }

        public void Register()
        {

        }
    }
}
