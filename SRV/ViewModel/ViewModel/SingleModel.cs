using SRV.ViewModel.EnityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRV.ViewModel
{
    public class SingleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public int AuthorId { get; set; }
        public int? PreviousId { get; set; }
        public string PreviousTitle { get; set; }
        public int? NextId { get; set; }
        public string NextTitle { get; set; }
        public DateTime PublishDateTime { get; set; }
        public AppraiseDto Appraise { get; set; }
        public IList<CommentDto> Comments { get; set; }

    }
}