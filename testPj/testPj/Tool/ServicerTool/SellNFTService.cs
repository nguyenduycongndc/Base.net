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
using testPj.Models;
using testPj.Services.Interface;
using testPj.Tool.ServicerTool.CheckBuys.ModelCheckBuys;
using testPj.Tool.ServicerTool.InterfaceSellNFT;

namespace testPj.Tool.ServicerTool
{
    public class SellNFTService: ISellNFT
    {
        private readonly ISellsService _sellsService;
        private readonly ILogger<SellNFTService> _logger;
        public SellNFTService(ILogger<SellNFTService> logger, ISellsService sellsService)
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
        public async Task<bool> CallGetMethodSell(List<SellModel> InputSell)
        {
            HttpClientHandler handler = new HttpClientHandler();
            CreateWalletModel _creteWallet = new CreateWalletModel();

            try
            {
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("http://ec2-13-125-111-150.ap-northeast-2.compute.amazonaws.com:9099/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string authInfo = "TJTpWG4Q9YdlE4Zh";
                    client.DefaultRequestHeaders.TryAddWithoutValidation("x-api-key", authInfo);
                    #region Consume GET method  
                    for (int j = 0; j < InputSell.Count(); j++)
                    {
                        HttpResponseMessage response = await client.GetAsync("/api/Sell/Hero?wallet=" + InputSell[j].AddressWallet + "&privateKey=" + InputSell[j].privateKey + "&tokenId=" + InputSell[j].Token_Id + "&price=" + InputSell[j].priceNFT);
                        if (response.IsSuccessStatusCode)
                        {
                            var httpResponseResult = response.Content.ReadAsStringAsync().ContinueWith(task => task.Result).Result;
                            string deleteCh = httpResponseResult.Remove(0, 1);
                            string deleteChx = deleteCh.Remove(deleteCh.Length - 1, 1);
                            //OutWalletModel _outWallet = JsonSerializer.Deserialize<OutWalletModel>(httpResponseResult);
                            var _sell = new CheckSellModel()
                            {
                                id = InputSell[j].Id,
                                heroId = InputSell[j].IdNFT,
                                transactionId = deleteChx,
                                ownerId = InputSell[j].AddressWallet,
                                priceNFT = InputSell[j].priceNFT,
                            };
                            if (string.IsNullOrEmpty(httpResponseResult))
                            {
                                return false;
                            }
                            else
                            {
                                var sell = await CheckSellHero(_sell);
                            }
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

            return true;

        }
        public async Task<ResultCheckBuyModel> CheckSellHero(CheckSellModel checkSellModel)
        {
            HttpClientHandler handler = new HttpClientHandler();
            ResultCheckBuyModel _resultcheckbuy = new ResultCheckBuyModel();
            SellActiveModel _sellsactive = new SellActiveModel();
            var unixTimestamp = UnixTimeNow();
            var hash = HashMD5(unixTimestamp);

            try
            {
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("http://test-svr.theatlantis.io:1236/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var dtcheck = new DtCheckSellModel()
                    {
                        checksum = hash,
                        unixTime = unixTimestamp,
                        heroId = checkSellModel.heroId,
                        transactionId = checkSellModel.transactionId,
                        ownerId = checkSellModel.ownerId,
                        pricesBNB = checkSellModel.priceNFT,
                    };
                    #region Consume GET method  
                    HttpResponseMessage response = await client.PostAsJsonAsync("/api/Bridge/sell-hero-confirm-in-market", dtcheck);
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
                            _sellsactive.Id = checkSellModel.id;
                            _sellsactive.IdNFT = result.data.id;
                            _sellsactive.Class = result.data.Class;
                            _sellsactive.rarity = result.data.rarity;
                            _sellsactive.AddressWallet = result.data.ownerId;
                            //_sellsactive.BNB = result.data.pricesBNB;
                            _sellsactive.USD = result.data.pricesUSD;
                            _sellsactive.Is_Selling = result.data.isSelling;
                            _sellsactive.Token_Id = result.data.tokenId;
                            _sellsactive.priceNFT = checkSellModel.priceNFT;
                            //var cre = UpdateNFT(_sellsactive);
                            var cre = await _sellsService.UpdateHistory(_sellsactive);
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
