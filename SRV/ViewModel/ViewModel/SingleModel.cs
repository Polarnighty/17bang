using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SRV.ViewModel
{
    public class SingleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public string Summary { get; set; }
        public int AuthorId { get; set; }
        public int? PreviousId { get; set; }
        public string PreviousTitle { get; set; }
        public int? NextId { get; set; }
        public string NextTitle { get; set; }
        public DateTime PublishDateTime { get; set; }
        public AppraiseModel Appraise { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<KeywordModel> Keywords { get; set; }
        public CommentModel Reply { get; set; }
        public PageModel Page { get; set; }
    }
}