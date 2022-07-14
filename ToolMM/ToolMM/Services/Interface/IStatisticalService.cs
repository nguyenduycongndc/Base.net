using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ToolMM.Models.StatisticalModel;

namespace ToolMM.Services.Interface
{
    public interface IStatisticalService
    {
        StatisticalRsModel GetAllStatistical(SearchStatisticalModel searchStatisticalModel);
    }
}
