using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Models
{
    public class NewModel
    {
        [Required(ErrorMessage = "* 标题不能为空")]
        public string Title { get; set; }
        [Required(ErrorMessage = "* 正文不能为空")]
        [AllowHtml]
        public string Body { get; set; }
        public string Summary { get; set; }
        [Required(ErrorMessage = "* 关键字不能为空")]
        public string KeyWords { get; set; }

    }
}