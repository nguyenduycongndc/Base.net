﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Data;
using ToolMM.Models;
using ToolMM.Repo;
using ToolMM.Repo.Interface;
using ToolMM.Services.Interface;

namespace ToolMM.Services
{
    public class SellsService : ISellsService
    {
        private readonly ILogger<SellsService> _logger;
        private readonly ISellsRepo _sellRepo;
        public SellsService(ISellsRepo sellRepo, ILogger<SellsService> logger)
        {
            _sellRepo = sellRepo;
            _logger = logger;
        }

        public async Task<bool> CreateHistory(BuysActiveModel buysActiveModel)
        {
            try
            {
                TransactionHistory wl = new TransactionHistory()
                {
                    IdNFT = buysActiveModel.IdNFT,
                    Class = buysActiveModel.Class,
                    Type = buysActiveModel.Type,
                    rarity = buysActiveModel.Rarity,
                    Sex = buysActiveModel.Sex,
                    AddressWallet = buysActiveModel.AddressWallet,
                    Elemental = buysActiveModel.Elemental,
                    Level = buysActiveModel.Level,
                    Token_Id = buysActiveModel.Token_Id,
                    TAU = buysActiveModel.TAU,
                    BNB = buysActiveModel.BNB,
                    USD = buysActiveModel.USD,
                    Buy_TAU = buysActiveModel.TAU,
                    Date_Sell = null,
                    Date_Buy = DateTime.Now,
                    Is_Selling = false,
                    IsCheck = 0,
                    IsActive = 1,
                };

                return await _sellRepo.CreateTransactionHistory(wl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public async Task<bool> UpdateHistory(SellActiveModel sellActiveModel)
        {
            try
            {
                var data = _sellRepo.GetHTDetail(sellActiveModel.Id);
                if (data == null) return false;

                data.Id = sellActiveModel.Id;
                data.IdNFT = sellActiveModel.IdNFT;
                data.Class = sellActiveModel.Class;
                data.Type = sellActiveModel.Type;
                data.rarity = sellActiveModel.Rarity;
                data.Sex = sellActiveModel.Sex;
                data.AddressWallet = sellActiveModel.AddressWallet;
                data.Token_Id = sellActiveModel.Token_Id;
                data.Elemental = sellActiveModel.Elemental;
                data.Level = sellActiveModel.Level;
                data.TAU = sellActiveModel.USD;
                data.BNB = data.BNB;
                data.USD = data.USD;
                data.Buy_TAU = data.Buy_TAU;
                data.Date_Buy = data.Date_Buy;
                data.Sell_TAU = sellActiveModel.priceNFT;
                data.Date_Sell = DateTime.Now;
                data.Is_Selling = sellActiveModel.Is_Selling;
                data.IsCheck = 0;
                data.IsActive = sellActiveModel.Is_Selling == true ? 0 : 1;
                data.Fee = sellActiveModel.Fee;

                return await _sellRepo.UpdateHistory(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public List<WalletModel> GetAllWallet()
        {
            var qr = _sellRepo.GetAll();
            List<WalletModel> lst = new List<WalletModel>();
            var listWallet = qr.Where(x => (x.IsDeleted != 1) && x.IsCheck == 1).Select(x => new WalletModel()
            {
                Id = x.Id,
                Address = x.AddressWallet,
                PrivateKey = x.PrivateKey,
                TAU = x.TAU,
                BNB = x.BNB,
                IsCheck = x.IsCheck,
            }).OrderBy(x => x.Id).ToList();
            return listWallet;
        }
        public List<WalletModel> GetAllWalletDrop(string q)
        {
            var qr = _sellRepo.GetAll();
            List<WalletModel> lst = new List<WalletModel>();
            var listWallet = qr.Where(x => (x.IsDeleted != 1) && x.IsCheck == 1 && (string.IsNullOrEmpty(q) || x.AddressWallet.Contains(q) || x.AddressWallet.Contains(q))).Select(x => new WalletModel()
            {
                Id = x.Id,
                Address = x.AddressWallet,
                TAU = x.TAU,
                BNB = x.BNB,
                IsCheck = x.IsCheck,
            }).OrderBy(x => x.Id).ToList();
            return listWallet;
        }

        public SellRsDataModel GetDataSell(SearchSellModel searchSellModel)
        {
            var qr = _sellRepo.GetAllSell();
            List<SellModel> lst = new List<SellModel>();
            var listSell = qr.Where(x => (searchSellModel.Type == "-1" || (searchSellModel.Type == "Hero" ? x.Class == "Hero" : x.Class == "Trứng"))
                                            && (searchSellModel.Rarity == "-1" || (searchSellModel.Rarity == "Common" ? x.rarity == "Common"
                                            : searchSellModel.Rarity == "UnCommon" ? x.rarity == "UnCommon"
                                            : searchSellModel.Rarity == "Rare" ? x.rarity == "Rare"
                                            : searchSellModel.Rarity == "Epic" ? x.rarity == "Epic"
                                            : searchSellModel.Rarity == "Lengend" ? x.rarity == "Lengend"
                                            : x.rarity == "Mythic"))
                                            && (x.AddressWallet.Contains(searchSellModel.Wallet) || string.IsNullOrEmpty(searchSellModel.Wallet))
                                          && (searchSellModel.IsActive == -1 || (searchSellModel.IsActive == 1 ? x.IsActive == 1 : x.IsActive == 0))).Select(x => new SellModel()
                                          {
                                              Id = x.Id,
                                              IdNFT = x.IdNFT,
                                              Class = x.Class,
                                              rarity = x.rarity,
                                              TAU = x.TAU,
                                              USD = x.USD,
                                              Sell_TAU = x.Sell_TAU,
                                              AddressWallet = x.AddressWallet,
                                              IsActive = x.IsActive,
                                              Is_Selling = x.Is_Selling,
                                          }).OrderBy(x => x.Id).ToList();
            var count = listSell.Count();
            lst = listSell.Skip(searchSellModel.StartNumber).Take(searchSellModel.PageSize).ToList();
            var data = new SellRsDataModel()
            {
                Data = lst,
                Count = listSell.Count(),
            };
            return data;
            //var data = new List<Object> { lst, listSell.Count() };
            //return data;
        }
        public List<SellModel> GetListDataSell(ChooseAll obj)
        {
            var qr = _sellRepo.GetAllSell();
            var wallet = _sellRepo.GetAll();

            var list = obj.listID.Split(",").ToList();
            List<SellModel> lst = new List<SellModel>();
            var listSell = qr.Where(x => list.Contains(x.Id.ToString())).Select(x => new SellModel()
            {
                Id = x.Id,
                IdNFT = x.IdNFT,
                Class = x.Class,
                rarity = x.rarity,
                TAU = x.TAU,
                USD = x.USD,
                Sell_TAU = x.Sell_TAU,
                AddressWallet = x.AddressWallet,
                privateKey = wallet.FirstOrDefault(a => a.AddressWallet == x.AddressWallet)?.PrivateKey,
                Token_Id = x.Token_Id,
                IsActive = x.IsActive,
                Is_Selling = x.Is_Selling,
                priceNFT = obj.priceNFT,
            }).OrderBy(x => x.Id).ToList();
            return listSell;
        }
        public List<SellRsModel> GetListDataFESell(ChooseAll obj)
        {
            var qr = _sellRepo.GetAllSell();
            var wallet = _sellRepo.GetAll();

            var list = obj.listID.Split(",").ToList();
            List<SellRsModel> lst = new List<SellRsModel>();
            var listSell = qr.Where(x => list.Contains(x.Id.ToString())).Select(x => new SellRsModel()
            {
                Id = x.Id,
                IdNFT = x.IdNFT,
                Class = x.Class,
                rarity = x.rarity,
                TAU = x.TAU,
                USD = x.USD,
                Sell_TAU = x.Sell_TAU,
                AddressWallet = x.AddressWallet,
                Token_Id = x.Token_Id,
                IsActive = x.IsActive,
                Is_Selling = x.Is_Selling,
                priceNFT = obj.priceNFT,
            }).OrderBy(x => x.Id).ToList();
            return listSell;
        }
        public SellRsModel GetDetailModels(int Id)
        {
            try
            {
                var data = _sellRepo.GetHTDetail(Id);

                var detail = new SellRsModel()
                {
                    Id = data.Id,
                    IdNFT = data.IdNFT,
                    Class = data.Class,
                    rarity = data.rarity,
                    TAU = data.TAU,
                    USD = data.USD,
                    Sell_TAU = data.Sell_TAU,
                    AddressWallet = data.AddressWallet,
                    Token_Id = data.Token_Id,
                    IsActive = data.IsActive,
                    Is_Selling = data.Is_Selling,
                    priceNFT = data.Sell_TAU,
                };

                return detail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
