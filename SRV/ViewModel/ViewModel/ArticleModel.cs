using BLL.Entites.EnityDto;
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
        public string Summary { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishDateTime { get; set; }

    }
}