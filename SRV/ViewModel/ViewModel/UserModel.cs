using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SRV.ViewModel
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "* 用户名必须填写")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* 密码必须填写")]
        public string Password { get; set; }
        [Required(ErrorMessage = "* 确认密码必须填写")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "* 邀请人必须填写")]
        public string InviterByName { get; set; }
        [Required(ErrorMessage = "* 邀请码必须填写")]
        [StringLength(maximumLength: 4, MinimumLength = 4, ErrorMessage = "* 邀请码只能是4位数字")]
        public string InviterCode { get; set; }

    }
}