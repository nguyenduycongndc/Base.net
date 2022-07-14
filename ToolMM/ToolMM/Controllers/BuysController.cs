using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ToolMM.Attributes;
using ToolMM.Models;
using ToolMM.Services.Interface;
using ToolMM.Tool.ServicerTool.InterfaceBuyNFT;

namespace ToolMM.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [BaseAuthorize]
    public class BuysController : Controller
    {
        private readonly ILogger<BuysController> _logger;
        //private readonly ISellService _sellService;
        private readonly IBuysService _buyItemsService;
        private readonly IBuyNFT _buyNFT;

        public BuysController(ILogger<BuysController> logger/*, ISellService sellService*/, IBuysService buyItemsService, IBuyNFT buyNFT)
        {
            _logger = logger;
            //_sellService = sellService;
            _buyItemsService = buyItemsService;
            _buyNFT = buyNFT;
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
        [Route("SaveDataBuy")]
        public async Task<bool> SaveDataBuy([FromBody] InputBuyModel inputBuyModel)
        {

            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return false;
                }
                /*var buyItemsServiceSuccess*/
                return await _buyItemsService.CreateData(inputBuyModel, _userInfo);
                //if (buyItemsServiceSuccess == true)
                //{
                //await _buyNFT.GetDataHero(inputBuyModel);
                //}
                //return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        [HttpGet]
        [Route("PauseDataBuy")]
        public async Task<bool> PauseDataBuy()
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return false;
                }
                return await _buyItemsService.PauseDataBuy();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
