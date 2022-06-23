using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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
        static HttpClient client = new HttpClient();
        //public string TokenRs()
        //{
        //    if (HttpContext.Items["Token"] is var Token == null)
        //    {
        //        return null;
        //    }
        //    return (string)Token;
        //}
        [HttpPost]
        [Route("InforWallet")]
        public CreateWalletModel InforWallet([FromBody] InputWalletModel inputWalletModel)
        {
            try
            {
                if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
                {
                    return null;
                }
                var _data = new CreateWalletModel()
                {
                    PrivateKey = inputWalletModel.PrivateKey,
                    AddressWallet = inputWalletModel.AddressWallet,
                    IsCheck = inputWalletModel.IsCheck,
                };
                CallGetMethod(_data);
                return _data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }

        }
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
            {
                return null;
            }
            //TokenRs();
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
        public async Task CallGetMethod(CreateWalletModel createWalletModel)
        {
            HttpClientHandler handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri("http://ec2-13-125-111-150.ap-northeast-2.compute.amazonaws.com:9099/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes("Akash:Vidhate"));
                string authInfo = "TJTpWG4Q9YdlE4Zh";
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("x-api-key", authInfo);
                client.DefaultRequestHeaders.TryAddWithoutValidation("x-api-key", authInfo);
                #region Consume GET method  

                HttpResponseMessage response = await client.GetAsync("api/Wallet/Info?wallet=" + createWalletModel.AddressWallet);
                if (response.IsSuccessStatusCode)
                {
                    string httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
                    CreateWalletModel test = new CreateWalletModel()
                    {
                        PrivateKey = createWalletModel.PrivateKey,
                        AddressWallet = createWalletModel.AddressWallet,
                        TAU = "",
                        BNB = httpResponseResult,
                        IsCheck = 0,
                    };
                    await CreateProductAsync(test);
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
                Console.ReadKey();
                #endregion
            }
        }

        public async Task<Object> CreateProductAsync(CreateWalletModel createWalletModel)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5001/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string authInfo = "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJuYmYiOjE2NTU5NTcxNDQsImV4cCI6MTY1NjA0MzU0NCwiaXNzIjoiaHR0cDovLzo6ODAiLCJhdWQiOiJodHRwOi8vOjo4MCJ9.NNy2x0P4zXEJl1ldhW9dNsjt2EY90Q6oKbkVf7Y2PiulWPntYoRWlgw39QHNTQETqdKUQzuG7AOcT_MR9VMn9A";
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authInfo);
                    #region Consume POST Method  

                    HttpResponseMessage responsePost = await client.PostAsJsonAsync("api/WalletManagement/Create", createWalletModel);
                    if (responsePost.IsSuccessStatusCode)
                    {
                        string httpResponseResult = responsePost.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
                        if (httpResponseResult == "false")
                        {
                            return null;
                        }
                        else return responsePost;
                       
                    }
                    return responsePost;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            
        }
    }
}
