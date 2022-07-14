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
using System.Threading.Tasks;
using ToolMM.Models;
using ToolMM.Services.Interface;
using ToolMM.Tool.ServicerTool.CheckBuys.ModelCheckBuys;
using ToolMM.Tool.ServicerTool.InterfaceBuyNFT;

namespace ToolMM.Tool.ServicerTool
{
    public class BuyNFTServive : IBuyNFT
    {
        private readonly ISellsService _sellsService;
        private readonly ILogger<BuyNFTServive> _logger;

        public BuyNFTServive(ILogger<BuyNFTServive> logger, ISellsService sellsService)
        {
            _logger = logger;
            _sellsService = sellsService;
        }
        public static string BRIGDE_CHECKSUM_KEY { get; } = "R026jm8BNZdUyMYria";
        public long UnixTimeNow()
        {
            var timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)timeSpan.TotalSeconds;
        }
        public string HashMD5(long unixTimestamp)
        {
            var hash = "";
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes($"key={BRIGDE_CHECKSUM_KEY}&sRmKXYf3cb&time={unixTimestamp}");

                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);

                // Convert hash byte array to string
                hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
            return hash;
        }

        public async Task<OutPut> GetDataHero(InputBuyModel inputBuyModel)
        {
            HttpClientHandler handler = new HttpClientHandler();
            OutPut _output = new OutPut();
            var unixTimestamp = UnixTimeNow();
            var hash = HashMD5(unixTimestamp);

            try
            {
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("http://test-svr.theatlantis.io:1236/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var detailWl = new ModelX()
                    {
                        checksum = hash,
                        unixTime = unixTimestamp,
                        filters = inputBuyModel != null ? inputBuyModel.Hero.filters : null,
                    };
                    #region Consume GET method  
                    if (detailWl.filters != null)
                    {
                        HttpResponseMessage response = await client.PostAsJsonAsync("/api/Bridge/list-hero-in-market", detailWl);
                        if (response.IsSuccessStatusCode)
                        {
                            string httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
                            var result = JsonConvert.DeserializeObject<OutPut>(httpResponseResult);
                            if (string.IsNullOrEmpty(httpResponseResult))
                            {
                                return null;
                            }
                            else
                            {
                                _output.Data = result.Data;
                            }
                        }
                    }
                    else return null;
                    #endregion
                }
                var walletDetail = _sellsService.GetAllWallet();
                if (_output.Data != null)
                {
                    await CallBuyHero(_output, walletDetail);
                }
                return _output;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        public async Task<Object> CallBuyHero(OutPut outPut, List<WalletModel> WalletModel)
        {
            HttpClientHandler handler = new HttpClientHandler();
            //CreateWalletModel _creteWallet = new CreateWalletModel();
            try
            {
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("http://ec2-13-125-111-150.ap-northeast-2.compute.amazonaws.com:9099/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string authInfo = "TJTpWG4Q9YdlE4Zh";
                    client.DefaultRequestHeaders.TryAddWithoutValidation("x-api-key", authInfo);
                    for (int j = 0; j < outPut.Data.Count(); j++)
                    {
                        Random random = new Random();

                        int index = random.Next(WalletModel.Count());
                        #region Consume GET method  
                        HttpResponseMessage response = await client.GetAsync("/api/Buy/Hero?wallet=" + WalletModel[index].Address + "&privateKey=" + WalletModel[index].PrivateKey + "&tokenId=" + outPut.Data[j].tokenId);
                        //call api thêm vào bảng lịch sử thống kê
                        if (response.IsSuccessStatusCode)
                        {
                            var httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
                            string deleteCh = httpResponseResult.Remove(0, 1);
                            string deleteChx = deleteCh.Remove(deleteCh.Length - 1, 1);
                            var _buys = new CheckBuysModel()
                            {
                                heroId = outPut.Data[j].id,
                                transactionId = deleteChx,
                                ownerId = WalletModel[index].Address,
                            };
                            if (string.IsNullOrEmpty(httpResponseResult))
                            {
                                return null;
                            }
                            else
                            {
                                var buys = await CheckBuysHero(_buys);
                            }
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
            return null;
        }




        public async Task<ResultCheckBuyModel> CheckBuysHero(CheckBuysModel checkBuysModel)
        {
            HttpClientHandler handler = new HttpClientHandler();
            ResultCheckBuyModel _resultcheckbuy = new ResultCheckBuyModel();
            BuysActiveModel _buysactive = new BuysActiveModel();
            var unixTimestamp = UnixTimeNow();
            var hash = HashMD5(unixTimestamp);

            try
            {
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("http://test-svr.theatlantis.io:1236/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var dtcheck = new DtCheckBuysModel()
                    {
                        checksum = hash,
                        unixTime = unixTimestamp,
                        heroId = checkBuysModel.heroId,
                        transactionId = checkBuysModel.transactionId,
                        ownerId = checkBuysModel.ownerId,

                    };
                    #region Consume GET method  
                    HttpResponseMessage response = await client.PostAsJsonAsync("/api/Bridge/buy-hero-confirm-in-market", dtcheck);
                    if (response.IsSuccessStatusCode)
                    {
                        var httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
                        var result = JsonConvert.DeserializeObject<ResultCheckBuyModel>(httpResponseResult);
                        if (string.IsNullOrEmpty(httpResponseResult))
                        {
                            return null;
                        }
                        else
                        {
                            _resultcheckbuy = result;

                            _buysactive.IdNFT = result.data.heroActive.id;
                            _buysactive.Class = result.data.heroActive.Class;
                            _buysactive.Type = "Hero";
                            _buysactive.Rarity = result.data.heroActive.rarity;
                            _buysactive.Sex = result.data.heroActive.sex;
                            _buysactive.AddressWallet = result.data.heroActive.ownerId;
                            _buysactive.Elemental = result.data.heroActive.elemental;
                            _buysactive.Level = result.data.heroActive.level;
                            _buysactive.BNB = result.data.heroActive.pricesBNB;
                            _buysactive.TAU = (double)(result.data.transaction != null ? result.data.transaction.tau : 0);
                            _buysactive.USD = (double)(result.data.transaction != null ? result.data.transaction.usd : 0);
                            _buysactive.Is_Selling = result.data.heroActive.isSelling;
                            _buysactive.Token_Id = result.data.heroActive.tokenId;
                            _buysactive.Token_Id = result.data.heroActive.tokenId;
                            _buysactive.Fee = 0;
                            var cre = await _sellsService.CreateHistory(_buysactive);
                            if (!cre) return null;
                        }
                    }
                    #endregion
                }
                return _resultcheckbuy;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
