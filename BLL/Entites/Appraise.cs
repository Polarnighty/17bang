using BLL.Entites.Interface;
namespace BLL.Entites
{
    public class Appraise : BaseEntity
    {
        public User Appraiser { get; set; }
        public int? AppraiserId { get; set; }
        public bool? IsAgree { get; set; }
        public int? ArticleId { get; set; }
        public int? CommentId { get; set; }

    }
}
