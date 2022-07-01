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
using testPj.Attributes;
using testPj.Models;
using testPj.Services.Interface;

namespace testPj.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [BaseAuthorize]
    public class BuyItemsController : Controller
    {
        private readonly ILogger<BuyItemsController> _logger;
        //private readonly ISellService _sellService;
        private readonly IBuyItemsService _buyItemsService;

        public BuyItemsController(ILogger<BuyItemsController> logger/*, ISellService sellService*/, IBuyItemsService buyItemsService)
        {
            _logger = logger;
            //_sellService = sellService;
            _buyItemsService = buyItemsService;
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
        public static string BRIGDE_CHECKSUM_KEY { get; } = "R026jm8BNZdUyMYria";
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
                return await _buyItemsService.CreateData(inputBuyModel, _userInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

            //HttpClientHandler handler = new HttpClientHandler();
            //OutPut _output = new OutPut();
            //try
            //{
            //    if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
            //    {
            //        return null;
            //    }
            //    using (var client = new HttpClient(handler))
            //    {
            //        client.BaseAddress = new Uri("http://test-svr.theatlantis.io:1236/");
            //        client.DefaultRequestHeaders.Accept.Clear();
            //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //        var hash = "";
            //        using (var md5Hash = MD5.Create())
            //        {
            //            // Byte array representation of source string
            //            var sourceBytes = Encoding.UTF8.GetBytes($"key={BRIGDE_CHECKSUM_KEY}&sRmKXYf3cb");

            //            // Generate hash value(Byte Array) for input data
            //            var hashBytes = md5Hash.ComputeHash(sourceBytes);

            //            // Convert hash byte array to string
            //            hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            //        }
            //        var detailWl = new ModelX()
            //        {
            //            checksum = hash,
            //            filters = inputBuyModel.Hero.filters,
            //        };
            //        #region Consume GET method  

            //        HttpResponseMessage response = await client.PostAsJsonAsync("/api/Bridge/list-hero-in-market", detailWl);
            //        if (response.IsSuccessStatusCode)
            //        {
            //            string httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
            //            var result = JsonConvert.DeserializeObject<OutPut>(httpResponseResult);
            //            if (string.IsNullOrEmpty(httpResponseResult))
            //            {
            //                return null;
            //            }
            //            else
            //            {
            //                _output.Data = result.Data;
            //            }
            //        }
            //        #endregion
            //    }
            //    var walletDetail = _sellService.GetAllWallet();

            //    CallBuyHero(_output, walletDetail);
            //    return _output;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex.Message);
            //    return null;
            //}

        }

        //public async Task<Object> CallBuyHero(OutPut outPut, List<WalletModel> WalletModel)
        //{
        //    HttpClientHandler handler = new HttpClientHandler();
        //    //CreateWalletModel _creteWallet = new CreateWalletModel();
        //    try
        //    {
        //        using (var client = new HttpClient(handler))
        //        {
        //            client.BaseAddress = new Uri("http://ec2-13-125-111-150.ap-northeast-2.compute.amazonaws.com:9099/");
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //            string authInfo = "TJTpWG4Q9YdlE4Zh";
        //            client.DefaultRequestHeaders.TryAddWithoutValidation("x-api-key", authInfo);
        //            //for (int i = 0; i < WalletModel.Count(); i++)
        //            //{
        //            for (int j = 0; j < outPut.Data.Count(); j++)
        //            {
        //                Random random = new Random();

        //                int index = random.Next(WalletModel.Count());
        //                #region Consume GET method  
        //                HttpResponseMessage response = await client.GetAsync("/api/Buy/Hero?wallet=" + WalletModel[index].Address + "&privateKey=" + WalletModel[index].PrivateKey + "&tokenId=" + outPut.Data[j].tokenId);
        //                //call api thêm vào bảng lịch sử thống kê
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    var httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
        //                    string deleteCh = httpResponseResult.Remove(0, 1);
        //                    string deleteChx = deleteCh.Remove(deleteCh.Length - 1, 1);
        //                    if (string.IsNullOrEmpty(httpResponseResult))
        //                    {
        //                        return null;
        //                    }
        //                    else
        //                    {
        //                        //_creteWallet.PrivateKey = createWalletModel.PrivateKey;
        //                        //_creteWallet.AddressWallet = createWalletModel.AddressWallet;
        //                        //_creteWallet.TAU = "";
        //                        //_creteWallet.BNB = httpResponseResult;
        //                        //_creteWallet.IsCheck = 0;

        //                        //var a = await _walletManagementService.CreateWallet(_creteWallet, _userInfo);
        //                        //if (!a) return null;

        //                    }
        //                }
        //                #endregion
        //                //}
        //            }
        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //        return null;
        //    }
        //    return null;
        //}
    }
}
