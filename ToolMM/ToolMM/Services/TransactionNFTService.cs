using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Models;
using ToolMM.Repo.Interface;
using ToolMM.Services.Interface;

namespace ToolMM.Services
{
    public class TransactionNFTService : ITransactionNFTService
    {
        private readonly ILogger<TransactionNFTService> _logger;
        private readonly ITransactionNFTRepo _transactionHeroRepo;
        public TransactionNFTService(ITransactionNFTRepo transactionHeroRepo, ILogger<TransactionNFTService> logger)
        {
            _logger = logger;
            _transactionHeroRepo = transactionHeroRepo;
        }
        #region Hero
        public TransactionHeroRsModel GetAllHeroService(TransactionSearchModel transactionSearchModel)
        {
            DateTime? _start = !string.IsNullOrEmpty(transactionSearchModel.start_date) ? DateTime.Parse(transactionSearchModel.start_date) : null;
            DateTime? _end = !string.IsNullOrEmpty(transactionSearchModel.end_date) ? DateTime.Parse(transactionSearchModel.end_date).AddDays(1) : null;
            var qr = _transactionHeroRepo.GetAllRepo();
            //var qr = _transactionHeroRepo.GetAllHeroRepo();
            var CountHero = qr.Where(x => x.Type == "Hero").Count();
            var CountTicket = qr.Where(x => x.Type == "Ticket").Count();
            var CountPacket = qr.Where(x => x.Type == "Packet").Count();
            var CountEgg = qr.Where(x => x.Type == "Egg").Count();
            var CountItem = qr.Where(x => x.Type == "Item").Count();
            List<TransactionHeroResultModel> lst = new List<TransactionHeroResultModel>();
            var listData = qr.Where(x => (string.IsNullOrEmpty(transactionSearchModel.start_date) || x.Date_Sell >= _start)
                                                && (string.IsNullOrEmpty(transactionSearchModel.end_date) || x.Date_Sell < _end) && x.Type == "Hero").Select(x => new TransactionHeroResultModel()
                                                {
                                                    Id = x.Id,
                                                    IdHero = x.IdNFT,
                                                    Rarity = x.rarity,
                                                    Level = x.Level,
                                                    Element = x.Elemental,
                                                    Genders = x.Sex,
                                                    Price = x.Sell_TAU,
                                                    Fee = x.Fee,
                                                    Time = x.Date_Sell.HasValue ? x.Date_Sell.Value.ToString("dd/MM/yyy HH:mm:ss") : "",
                                                }).OrderBy(x => x.Id).ToList();
            var count = listData.Count();
            lst = listData.Skip(transactionSearchModel.StartNumber).Take(transactionSearchModel.PageSize).ToList();
            var data = new TransactionHeroRsModel()
            {
                Data = lst,
                Count = listData.Count(),
                Total_NFT = qr.Count(),
                Count_Hero = CountHero,
                Count_Ticket = CountTicket,
                Count_Packet = CountPacket,
                Count_Egg = CountEgg,
                Count_Item = CountItem,
            };
            return data;
            //var data = new List<Object> { lst, listData.Count() };
            //return data;
        }
        #endregion
        #region Item
        public TransactionItemRsModel GetAllItemService(TransactionSearchModel transactionSearchModel)
        {
            DateTime? _start = !string.IsNullOrEmpty(transactionSearchModel.start_date) ? DateTime.Parse(transactionSearchModel.start_date) : null;
            DateTime? _end = !string.IsNullOrEmpty(transactionSearchModel.end_date) ? DateTime.Parse(transactionSearchModel.end_date).AddDays(1) : null;
            var qr = _transactionHeroRepo.GetAllRepo();
            var CountHero = qr.Where(x => x.Type == "Hero").Count();
            var CountTicket = qr.Where(x => x.Type == "Ticket").Count();
            var CountPacket = qr.Where(x => x.Type == "Packet").Count();
            var CountEgg = qr.Where(x => x.Type == "Egg").Count();
            var CountItem = qr.Where(x => x.Type == "Item").Count();
            List<TransactionItemResultModel> lst = new List<TransactionItemResultModel>();
            var listData = qr.Where(x => (string.IsNullOrEmpty(transactionSearchModel.start_date) || x.Date_Sell >= _start)
                                                && (string.IsNullOrEmpty(transactionSearchModel.end_date) || x.Date_Sell < _end) && x.Type == "Item").Select(x => new TransactionItemResultModel()
                                                {
                                                    Id = x.Id,
                                                    IdItem = x.IdNFT,
                                                    Rarity = x.rarity,
                                                    Level = x.Level,
                                                    Price = x.Sell_TAU,
                                                    Fee = x.Fee,
                                                    Time = x.Date_Sell.HasValue ? x.Date_Sell.Value.ToString("dd/MM/yyy HH:mm:ss") : "",
                                                }).OrderBy(x => x.Id).ToList();
            var count = listData.Count();
            lst = listData.Skip(transactionSearchModel.StartNumber).Take(transactionSearchModel.PageSize).ToList();
            var data = new TransactionItemRsModel()
            {
                Data = lst,
                Count = listData.Count(),
                Total_NFT = qr.Count(),
                Count_Hero = CountHero,
                Count_Ticket = CountTicket,
                Count_Packet = CountPacket,
                Count_Egg = CountEgg,
                Count_Item = CountItem,
            };
            return data;
            //var data = new List<Object> { lst, listData.Count() };
            //return data;
        }
        #endregion
        #region Ticket
        public TransactionTicketRsModel GetAllTicketService(TransactionSearchModel transactionSearchModel)
        {
            DateTime? _start = !string.IsNullOrEmpty(transactionSearchModel.start_date) ? DateTime.Parse(transactionSearchModel.start_date) : null;
            DateTime? _end = !string.IsNullOrEmpty(transactionSearchModel.end_date) ? DateTime.Parse(transactionSearchModel.end_date).AddDays(1) : null;
            var qr = _transactionHeroRepo.GetAllRepo();
            var CountHero = qr.Where(x => x.Type == "Hero").Count();
            var CountTicket = qr.Where(x => x.Type == "Ticket").Count();
            var CountPacket = qr.Where(x => x.Type == "Packet").Count();
            var CountEgg = qr.Where(x => x.Type == "Egg").Count();
            var CountItem = qr.Where(x => x.Type == "Item").Count();
            List<TransactionTicketResultModel> lst = new List<TransactionTicketResultModel>();
            var listData = qr.Where(x => (string.IsNullOrEmpty(transactionSearchModel.start_date) || x.Date_Sell >= _start)
                                                && (string.IsNullOrEmpty(transactionSearchModel.end_date) || x.Date_Sell < _end) && x.Type == "Ticket").Select(x => new TransactionTicketResultModel()
                                                {
                                                    Id = x.Id,
                                                    IdTicket = x.IdNFT,
                                                    Rarity = x.rarity,
                                                    Price = x.Sell_TAU,
                                                    Fee = x.Fee,
                                                    Time = x.Date_Sell.HasValue ? x.Date_Sell.Value.ToString("dd/MM/yyy HH:mm:ss") : "",
                                                }).OrderBy(x => x.Id).ToList();
            var count = listData.Count();
            lst = listData.Skip(transactionSearchModel.StartNumber).Take(transactionSearchModel.PageSize).ToList();
            var data = new TransactionTicketRsModel()
            {
                Data = lst,
                Count = listData.Count(),
                Total_NFT = qr.Count(),
                Count_Hero = CountHero,
                Count_Ticket = CountTicket,
                Count_Packet = CountPacket,
                Count_Egg = CountEgg,
                Count_Item = CountItem,
            };
            return data;
        }
        #endregion
        #region Pack
        public TransactionPackRsModel GetAllPackService(TransactionSearchModel transactionSearchModel)
        {
            DateTime? _start = !string.IsNullOrEmpty(transactionSearchModel.start_date) ? DateTime.Parse(transactionSearchModel.start_date) : null;
            DateTime? _end = !string.IsNullOrEmpty(transactionSearchModel.end_date) ? DateTime.Parse(transactionSearchModel.end_date).AddDays(1) : null;
            var qr = _transactionHeroRepo.GetAllRepo();
            var CountHero = qr.Where(x => x.Type == "Hero").Count();
            var CountTicket = qr.Where(x => x.Type == "Ticket").Count();
            var CountPacket = qr.Where(x => x.Type == "Packet").Count();
            var CountEgg = qr.Where(x => x.Type == "Egg").Count();
            var CountItem = qr.Where(x => x.Type == "Item").Count();
            List<TransactionPackResultModel> lst = new List<TransactionPackResultModel>();
            var listData = qr.Where(x => (string.IsNullOrEmpty(transactionSearchModel.start_date) || x.Date_Sell >= _start)
                                                && (string.IsNullOrEmpty(transactionSearchModel.end_date) || x.Date_Sell < _end) && x.Type == "Ticket").Select(x => new TransactionPackResultModel()
                                                {
                                                    Id = x.Id,
                                                    IdPack = x.IdNFT,
                                                    Rarity = x.rarity,
                                                    Price = x.Sell_TAU,
                                                    Fee = x.Fee,
                                                    Time = x.Date_Sell.HasValue ? x.Date_Sell.Value.ToString("dd/MM/yyy HH:mm:ss") : "",
                                                }).OrderBy(x => x.Id).ToList();
            var count = listData.Count();
            lst = listData.Skip(transactionSearchModel.StartNumber).Take(transactionSearchModel.PageSize).ToList();
            var data = new TransactionPackRsModel()
            {
                Data = lst,
                Count = listData.Count(),
                Total_NFT = qr.Count(),
                Count_Hero = CountHero,
                Count_Ticket = CountTicket,
                Count_Packet = CountPacket,
                Count_Egg = CountEgg,
                Count_Item = CountItem,
            };
            return data;
        }
        #endregion
        #region Egg
        public TransactionEggRsModel GetAllEggService(TransactionSearchModel transactionSearchModel)
        {
            DateTime? _start = !string.IsNullOrEmpty(transactionSearchModel.start_date) ? DateTime.Parse(transactionSearchModel.start_date) : null;
            DateTime? _end = !string.IsNullOrEmpty(transactionSearchModel.end_date) ? DateTime.Parse(transactionSearchModel.end_date).AddDays(1) : null;
            var qr = _transactionHeroRepo.GetAllRepo();
            var CountHero = qr.Where(x => x.Type == "Hero").Count();
            var CountTicket = qr.Where(x => x.Type == "Ticket").Count();
            var CountPacket = qr.Where(x => x.Type == "Packet").Count();
            var CountEgg = qr.Where(x => x.Type == "Egg").Count();
            var CountItem = qr.Where(x => x.Type == "Item").Count();
            List<TransactionEggResultModel> lst = new List<TransactionEggResultModel>();
            var listData = qr.Where(x => (string.IsNullOrEmpty(transactionSearchModel.start_date) || x.Date_Sell >= _start)
                                                && (string.IsNullOrEmpty(transactionSearchModel.end_date) || x.Date_Sell < _end) && x.Type == "Ticket").Select(x => new TransactionEggResultModel()
                                                {
                                                    Id = x.Id,
                                                    IdEgg = x.IdNFT,
                                                    Rarity = x.rarity,
                                                    Price = x.Sell_TAU,
                                                    Fee = x.Fee,
                                                    Time = x.Date_Sell.HasValue ? x.Date_Sell.Value.ToString("dd/MM/yyy HH:mm:ss") : "",
                                                }).OrderBy(x => x.Id).ToList();
            var count = listData.Count();
            lst = listData.Skip(transactionSearchModel.StartNumber).Take(transactionSearchModel.PageSize).ToList();
            var data = new TransactionEggRsModel()
            {
                Data = lst,
                Count = listData.Count(),
                Total_NFT = qr.Count(),
                Count_Hero = CountHero,
                Count_Ticket = CountTicket,
                Count_Packet = CountPacket,
                Count_Egg = CountEgg,
                Count_Item = CountItem,
            };
            return data;
        }
        #endregion
    }
}
