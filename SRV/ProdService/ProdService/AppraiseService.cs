using BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ProdService
{
    public class AppraiseService :BaseService
    {
        private AppraiseRepositary appraiseRepositary;
        public AppraiseService()
        {
            appraiseRepositary = new AppraiseRepositary(context);
        }

    }
}
