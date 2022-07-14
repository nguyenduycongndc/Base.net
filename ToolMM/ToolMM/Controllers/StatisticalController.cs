using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Attributes;
using ToolMM.Models;
using ToolMM.Services.Interface;
using static ToolMM.Models.StatisticalModel;

namespace ToolMM.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [BaseAuthorize]
    public class StatisticalController : Controller
    {
        private readonly ILogger<StatisticalController> _logger;
        private readonly IStatisticalService _statisticalService;

        public StatisticalController(ILogger<StatisticalController> logger, IStatisticalService statisticalService)
        {
            _logger = logger;
            _statisticalService = statisticalService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
            {
                return null;
            }
            return View();
        }
        [HttpPost]
        [Route("SearchStatistical")]
        public StatisticalRsModel SearchStatistical([FromBody] SearchStatisticalModel searchStatisticalModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                return _statisticalService.GetAllStatistical(searchStatisticalModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
