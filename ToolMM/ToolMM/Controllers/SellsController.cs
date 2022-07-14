using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToolMM.Attributes;
using ToolMM.Models;
using ToolMM.Services.Interface;
using ToolMM.Tool.ServicerTool.CheckBuys.ModelCheckBuys;
using ToolMM.Tool.ServicerTool.InterfaceSellNFT;

namespace ToolMM.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [BaseAuthorize]
    public class SellsController : Controller
    {
        private readonly ILogger<SellsController> _logger;
        private readonly ISellsService _sellsService;
        private readonly ISellNFT _sellNFT;
        public SellsController(ILogger<SellsController> logger, ISellsService sellService, ISellNFT sellNFT)
        {
            _logger = logger;
            _sellsService = sellService;
            _sellNFT = sellNFT;
        }
        //public static string BRIGDE_CHECKSUM_KEY { get; } = "R026jm8BNZdUyMYria";
        //public long UnixTimeNow()
        //{
        //    var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
        //    return (long)timeSpan.TotalSeconds;
        //}
        //public string HashMD5(long unixTimestamp)
        //{
        //    var hash = "";
        //    using (var md5Hash = MD5.Create())
        //    {
        //        // Byte array representation of source string
        //        var sourceBytes = Encoding.UTF8.GetBytes($"key={BRIGDE_CHECKSUM_KEY}&sRmKXYf3cb&time={unixTimestamp}");

        //        // Generate hash value(Byte Array) for input data
        //        var hashBytes = md5Hash.ComputeHash(sourceBytes);

        //        // Convert hash byte array to string
        //        hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
        //    }
        //    return hash;
        //}
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
            {
                return null;
            }
            return View();
        }
        public async Task<bool> Create(BuysActiveModel buysActiveModel)
        {
            try
            {
                //if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                //{
                //    return false;
                //}
                return await _sellsService.CreateHistory(buysActiveModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        //[HttpGet]
        //[Route("UpdateNFT")]
        public async Task<bool> UpdateNFT(SellActiveModel sellActiveModel)
        {
            try
            {
                return await _sellsService.UpdateHistory(sellActiveModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        [HttpGet]
        [Route("SelectWallet")]
        public List<WalletModel> SelectWallet()
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                var walletDetail = _sellsService.GetAllWallet();
                return walletDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        [HttpGet]
        [Route("Dropdown")]
        public List<WalletModel> Dropdown(string q)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                return _sellsService.GetAllWalletDrop(q);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        [HttpPost]
        [Route("Search")]
        public SellRsDataModel Search([FromBody] SearchSellModel searchSellModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                return _sellsService.GetDataSell(searchSellModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        [HttpPost]
        [Route("ListNTFSell")]
        public Task<bool>/*List<SellRsModel>*/ ListNTFSell([FromBody] ChooseAll obj)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                var InputSell = _sellsService.GetListDataSell(obj);
                if (InputSell != null)
                {
                   var rsSell = _sellNFT.CallGetMethodSell(InputSell);
                }
                return _sellNFT.CallGetMethodSell(InputSell);
                //return _sellsService.GetListDataFESell(obj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        //public async Task<bool> CallGetMethodSell(List<SellModel> InputSell)
        //{
        //    HttpClientHandler handler = new HttpClientHandler();
        //    CreateWalletModel _creteWallet = new CreateWalletModel();

        //    try
        //    {
        //        using (var client = new HttpClient(handler))
        //        {
        //            client.BaseAddress = new Uri("http://ec2-13-125-111-150.ap-northeast-2.compute.amazonaws.com:9099/");
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            string authInfo = "TJTpWG4Q9YdlE4Zh";
        //            client.DefaultRequestHeaders.TryAddWithoutValidation("x-api-key", authInfo);
        //            #region Consume GET method  
        //            for (int j = 0; j < InputSell.Count(); j++)
        //            {
        //                HttpResponseMessage response = await client.GetAsync("/api/Sell/Hero?wallet=" + InputSell[j].AddressWallet + "&privateKey=" + InputSell[j].privateKey + "&tokenId=" + InputSell[j].Token_Id + "&price=" + InputSell[j].priceNFT);
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    var httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
        //                    string deleteCh = httpResponseResult.Remove(0, 1);
        //                    string deleteChx = deleteCh.Remove(deleteCh.Length - 1, 1);
        //                    //OutWalletModel _outWallet = JsonSerializer.Deserialize<OutWalletModel>(httpResponseResult);
        //                    var _sell = new CheckSellModel()
        //                    {
        //                        id = InputSell[j].Id,
        //                        heroId = InputSell[j].IdNFT,
        //                        transactionId = deleteChx,
        //                        ownerId = InputSell[j].AddressWallet,
        //                        priceNFT = InputSell[j].priceNFT,
        //                    };
        //                    if (string.IsNullOrEmpty(httpResponseResult))
        //                    {
        //                        return false;
        //                    }
        //                    else
        //                    {
        //                        var sell = await CheckSellHero(_sell);
        //                    }
        //                }
        //            }
        //            #endregion
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return false;
        //    }

        //    return true;

        //}
        //public async Task<ResultCheckBuyModel> CheckSellHero(CheckSellModel checkSellModel)
        //{
        //    HttpClientHandler handler = new HttpClientHandler();
        //    ResultCheckBuyModel _resultcheckbuy = new ResultCheckBuyModel();
        //    SellActiveModel _sellsactive = new SellActiveModel();
        //    var unixTimestamp = UnixTimeNow();
        //    var hash = HashMD5(unixTimestamp);

        //    try
        //    {
        //        using (var client = new HttpClient(handler))
        //        {
        //            client.BaseAddress = new Uri("http://test-svr.theatlantis.io:1236/");
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            var dtcheck = new DtCheckSellModel()
        //            {
        //                checksum = hash,
        //                unixTime = unixTimestamp,
        //                heroId = checkSellModel.heroId,
        //                transactionId = checkSellModel.transactionId,
        //                ownerId = checkSellModel.ownerId,
        //                pricesBNB = checkSellModel.priceNFT,
        //            };
        //            #region Consume GET method  
        //            HttpResponseMessage response = await client.PostAsJsonAsync("/api/Bridge/sell-hero-confirm-in-market", dtcheck);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                var httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
        //                var result = JsonConvert.DeserializeObject<ResultCheckBuyModel>(httpResponseResult);
        //                if (string.IsNullOrEmpty(httpResponseResult))
        //                {
        //                    return null;
        //                }
        //                else
        //                {
        //                    _resultcheckbuy = result;
        //                    _sellsactive.Id = checkSellModel.id;
        //                    _sellsactive.IdNFT = result.data.id;
        //                    _sellsactive.Class = result.data.Class;
        //                    _sellsactive.rarity = result.data.rarity;
        //                    _sellsactive.AddressWallet = result.data.ownerId;
        //                    //_sellsactive.BNB = result.data.pricesBNB;
        //                    _sellsactive.USD = result.data.pricesUSD;
        //                    _sellsactive.Is_Selling = result.data.isSelling;
        //                    _sellsactive.Token_Id = result.data.tokenId;
        //                    _sellsactive.priceNFT = checkSellModel.priceNFT;
        //                    //var cre = UpdateNFT(_sellsactive);
        //                    var cre = await _sellsService.UpdateHistory(_sellsactive);
        //                    if (!cre) return null;
        //                }
        //            }
        //            #endregion
        //        }
        //        return _resultcheckbuy;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return null;
        //    }
        //}

        [HttpGet]
        [Route("Detail")]
        public SellRsModel Detail(int id)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                var userDetail = _sellsService.GetDetailModels(id);
                return userDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
