using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{
    public class LogOnModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "* 用户名必须填写")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* 密码必须填写")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
