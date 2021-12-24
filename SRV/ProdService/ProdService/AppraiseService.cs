using BLL.Repositories;
using Global;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ProdService
{
    public class AppraiseService :BaseService
    {
        private AppraiseRepository appraiseRepositary;
        public AppraiseService()
        {
            appraiseRepositary = new AppraiseRepository(context);
        }

        public AppraiseModel GetAppraiseCount(int id)
        {
            var appraiseDto = new AppraiseModel();
            appraiseDto.AgreeCount = appraiseRepositary.GetAppraiseCount(id, AppraiseType.Comment);
            appraiseDto.DisAgreeCount = appraiseRepositary.GetAppraiseCount(id, AppraiseType.Comment,false);
            return appraiseDto;
        }

    }
}
