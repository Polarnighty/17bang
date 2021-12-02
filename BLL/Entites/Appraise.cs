
namespace BLL.Entites
{
    public class Appraise : BaseEntity
    {
        public User Appraiser { get; set; }
        public int AppraiserId { get; set; }
        public bool? Agree { get; set; }
    }
}
