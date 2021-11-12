using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterface
{
    public interface IArticleService
    {
        string GerPwdById(int id);
        string Register(int id);

    }
}
