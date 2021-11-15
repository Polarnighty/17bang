using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRV.ViewModel
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime PublishDateTime { get; set; }

    }
}