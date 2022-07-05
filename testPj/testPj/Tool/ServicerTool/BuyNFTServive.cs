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
using testPj.Tool.ServicerTool.InterfaceBuyNFT;

namespace testPj.Tool.ServicerTool
{
    public class BuyNFTServive : IBuyNFT
    {
        private readonly ISellsService _sellsService;
        private readonly ILogger<BuyNFTServive> _logger;
        private readonly ISellsService _sellService;

        public BuyNFTServive(ILogger<BuyNFTServive> logger, ISellsService sellsService, ISellsService sellService)
        {
            _sellService = sellService;
            _logger = logger;
            _sellsService = sellsService;
        }
        public static string BRIGDE_CHECKSUM_KEY { get; } = "R026jm8BNZdUyMYria";
        long unixTimestamp { get; } = (long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;//lỗi

        public string HashMD5()
        {
            //Int32 unixTimestamp = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
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
            try
            {
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("http://test-svr.theatlantis.io:1236/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var hash = HashMD5();
                    var detailWl = new ModelX()
                    {
                        checksum = hash,
                        unixTime = unixTimestamp,
                        filters = inputBuyModel != null ? inputBuyModel.Hero.filters : null,
                    };
                    #region Consume GET method  

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
                    #endregion
                }
                var walletDetail = _sellService.GetAllWallet();

                await CallBuyHero(_output, walletDetail);
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
                            var test = new CheckBuysModel()
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
                                var test1 = await CheckBuysHero(test);
                                if (test1 != null)
                                {

                                }

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
            try
            {
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri("http://test-svr.theatlantis.io:1236/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var hash = HashMD5();
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
                            _resultcheckbuy.code = result.code;
                            _resultcheckbuy.text = result.text;
                            _resultcheckbuy.msg = result.msg;
                            _resultcheckbuy.desc = result.desc;
                            _resultcheckbuy.data = new ResultDataCheckBuyModel()
                            {
                                id = result.data.id,
                                ticketId = result.data.ticketId,
                                tokenId = result.data.tokenId,
                                elemental = result.data.elemental,
                                elemental2 = result.data.elemental2,
                                elemental3 = result.data.elemental3,
                                Class = result.data.Class,
                                rarity = result.data.rarity,
                                skillActiveId = result.data.skillActiveId,
                                skillPassiveId = result.data.skillPassiveId,
                                ownerId = result.data.ownerId,
                                ownerIdOffer = result.data.ownerIdOffer,
                                name = result.data.name,
                                sex = result.data.sex,
                                view = result.data.view,
                                level = result.data.level,
                                percentLevelUp = result.data.percentLevelUp,
                                eyes = result.data.eyes,
                                hair = result.data.hair,
                                tattoo = result.data.tattoo,
                                attack = result.data.attack,
                                armor = result.data.armor,
                                hp = result.data.hp,
                                speed = result.data.speed,
                                wings = result.data.wings,
                                Base = result.data.Base,
                                horn = result.data.horn,
                                pet = result.data.pet,
                                armorItem = result.data.armorItem,
                                pricesBNB = result.data.pricesBNB,
                                pricesUSD = result.data.pricesUSD,
                                isSelling = result.data.isSelling,
                                star = result.data.star,
                                breedCount = result.data.breedCount,
                                spiritId = result.data.spiritId,
                                lastBreedingTime = result.data.lastBreedingTime,
                                momId = result.data.momId,
                                dadId = result.data.dadId,
                                exp = result.data.exp,
                                critDame = result.data.critDame,
                                critRate = result.data.critRate,
                                evasion = result.data.evasion,
                                energy = result.data.energy,
                                energyMax = result.data.energyMax,
                                levelCapCurentStar = result.data.levelCapCurentStar,
                                levelCapNextStar = result.data.levelCapNextStar,
                                upgradeStarUSDFee = result.data.upgradeStarUSDFee,
                                upgradeStarGoldFee = result.data.upgradeStarGoldFee,
                                listSkillPassiveDto = result.data.listSkillPassiveDto.ToList(),
                                listSkillActiveDto = result.data.listSkillActiveDto.ToList(),
                                baseHp = result.data.baseHp,
                                baseAttack = result.data.baseAttack,
                                baseArmor = result.data.baseArmor,
                                baseSpeed = result.data.baseSpeed,
                                ownerRent = result.data.ownerRent,
                                feeRent = result.data.feeRent,
                                hourEndRent = result.data.hourEndRent,
                                status = result.data.status,
                                timeEndRent = result.data.timeEndRent,
                                timeStartRent = result.data.timeStartRent,
                                lockTime = result.data.lockTime,
                            };

                            _buysactive.IdNFT = result.data.id;
                            _buysactive.Class = result.data.Class;
                            _buysactive.rarity = result.data.rarity;
                            _buysactive.AddressWallet = result.data.ownerId;
                            _buysactive.BNB = result.data.pricesBNB;
                            _buysactive.USD = result.data.pricesUSD;
                            _buysactive.Is_Selling = result.data.isSelling;
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
