using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using testPj.Attributes;
using testPj.Models;

namespace testPj.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [BaseAuthorize]
    public class BuyItemsController : Controller
    {
        private readonly ILogger<BuyItemsController> _logger;

        public BuyItemsController(ILogger<BuyItemsController> logger)
        {
            _logger = logger;
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
        public static string ExcehangeMoney(int money)
        {
            try
            {
                var _tau = (money * 285).ToString();

                return _tau;
            }
            catch (Exception)
            {

                return null;
            }
        }
        [HttpPost]
        [Route("ListEggHero")]
        public async Task<InputBuyModel> ListEggHero([FromBody] InputBuyModel inputBuyModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                //var _data = new InputBuyModel()
                //{
                    
                //};
                //var _result = await CallBuyEgg();
                return inputBuyModel;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }

        }

        public async Task<CreateWalletModel> CallBuyEgg()
        {
            HttpClientHandler handler = new HttpClientHandler();
            //CreateWalletModel _creteWallet = new CreateWalletModel();
            try
            {
                using (var client = new HttpClient(handler))
                {
                    //client.BaseAddress = new Uri("");
                    //client.DefaultRequestHeaders.Accept.Clear();
                    //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    ////string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes("Akash:Vidhate"));
                    //string authInfo = "TJTpWG4Q9YdlE4Zh";
                    ////client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-api-key", authInfo);
                    //client.DefaultRequestHeaders.TryAddWithoutValidation("x-api-key", authInfo);
                    //#region Consume GET method  

                    //HttpResponseMessage response = await client.GetAsync("api/Wallet/Info?wallet=" + "");
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    string httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
                    //    if (string.IsNullOrEmpty(httpResponseResult))
                    //    {
                    //        return null;
                    //    }
                    //    else
                    //    {
                    //        //_creteWallet.PrivateKey = createWalletModel.PrivateKey;
                    //        //_creteWallet.AddressWallet = createWalletModel.AddressWallet;
                    //        //_creteWallet.TAU = "";
                    //        //_creteWallet.BNB = httpResponseResult;
                    //        //_creteWallet.IsCheck = 0;

                    //        //var a = await _walletManagementService.CreateWallet(_creteWallet, _userInfo);
                    //        //if (!a) return null;

                    //    }
                    //}
                    //#endregion
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            return null;
        }
    }
}
