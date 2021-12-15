using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRV.ViewModel
{
    public class NewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "* 标题必须填写")]
        public string Title { get; set; }
        [Required(ErrorMessage = "* 内容必须填写")]
        [AllowHtml]
        public string Body { get; set; }
        //[Required(ErrorMessage = "* 摘要必须填写")]
        public string Summary { get; set; }
        public string Keywords { get; set; }
        public int? AuthorId { get; set; }
        public DateTime PublishDateTime { get; set; }

    }
}