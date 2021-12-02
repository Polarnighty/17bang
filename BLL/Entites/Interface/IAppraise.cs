using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entites.Interface
{
    interface IAppraise
    {
        void Agree(User user);
        void DisAgree(User user);
    }
}
