using BLL.Entites.Interface;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Entites
{
    public class Article : BaseEntity, IAppraise
    {
        [MaxLength(20)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Summary { get; set; }
        [Column(TypeName = "ntext")]
        public string Body { get; set; }
        public DateTime PublishDateTime { get; set; }
        public User Author { get; set; }
        public int AuthorId { get; set; }
        public List<Appraise> Appraises { get; set; }
        public IList<Comment> Comments { get; set; }

        public void Agree(User user)
        {
            var appraise = Appraises.Where(a => a.AppraiserId == user.Id).SingleOrDefault();
            if (appraise==null)
            {
                Appraises.Add(new Appraise { Appraiser = user, Agree = true });
            }
            else
            {
                if (appraise.Agree==true)
                {
                    appraise.Agree = null;
                    return;
                }
                appraise.Agree = true;
            }
        }

        public void DisAgree(User user)
        {
            var appraise = Appraises.Where(a => a.AppraiserId == user.Id).SingleOrDefault();
            if (appraise == null)
            {
                Appraises.Add(new Appraise { Appraiser = user, Agree = false });
            }
            else
            {
                if (appraise.Agree == false)
                {
                    appraise.Agree = null;
                    return;
                }
                appraise.Agree = false;
            }
        }

    }
}
