using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel.EnityDto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int? CommentId { get; set; }
        public int CommentatorId { get; set; }
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }
        public AppraiseDto Appraises { get; set; }
        public IList<CommentDto> CommentBy { get; set; }

    }
}
