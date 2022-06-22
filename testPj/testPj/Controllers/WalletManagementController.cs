using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Attributes;
using testPj.Models;
using testPj.Services.Interface;

namespace testPj.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [BaseAuthorize]
    public class WalletManagementController : Controller
    {
        private readonly ILogger<WalletManagementController> _logger;
        private readonly IWalletManagementService _walletManagementService;

        public WalletManagementController(ILogger<WalletManagementController> logger, IWalletManagementService walletManagementService)
        {
            _logger = logger;
            _walletManagementService = walletManagementService;
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
        [Route("Search")]
        public List<Object> Search([FromBody] SearchWalletModel searchWalletModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                return _walletManagementService.GetAllWallet(searchWalletModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        [HttpPost]
        [Route("Create")]
        public async Task<bool> Create([FromBody] CreateWalletModel add)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return false;
                }
                return await _walletManagementService.CreateWallet(add, _userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        [HttpPost]
        [Route("Checked")]
        public async Task<bool> Checked([FromBody] CheckedWalletModel input)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return false;
                }
                return await _walletManagementService.CheckedWallet(input, _userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        [HttpGet]
        [Route("Detail")]
        public DetailWalletModel Detail(int id)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                var walletDetail = _walletManagementService.GetDetailModels(id);
                return walletDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<bool> Delete(int id)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return false;
                }
                return await _walletManagementService.DeleteWallet(id, _userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
