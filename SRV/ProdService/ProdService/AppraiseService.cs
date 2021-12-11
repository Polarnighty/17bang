using BLL.Repositories;
using SRV.ViewModel.EnityDto;
using Global;
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

        public AppraiseDto GetAppraiseCount(int id)
        {
            var appraiseDto = new AppraiseDto();
            appraiseDto.AgreeCount = appraiseRepositary.GetAppraiseCount(id, AppraiseType.Comment);
            appraiseDto.DisAgreeCount = appraiseRepositary.GetAppraiseCount(id, AppraiseType.Comment,false);
            return appraiseDto;
        }

    }
}
