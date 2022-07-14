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
    public class TransactionHeroService : ITransactionHeroService
    {
        private readonly ILogger<TransactionHeroService> _logger;
        private readonly ITransactionHeroRepo _transactionHeroRepo;
        public TransactionHeroService(ITransactionHeroRepo transactionHeroRepo, ILogger<TransactionHeroService> logger)
        {
            _logger = logger;
            _transactionHeroRepo = transactionHeroRepo;
        }
        public TransactionHeroRsModel GetAllHeroService(TransactionHeroSearchModel transactionHeroSearchModel)
        {
            DateTime? _start = !string.IsNullOrEmpty(transactionHeroSearchModel.start_date) ? DateTime.Parse(transactionHeroSearchModel.start_date) : null;
            DateTime? _end = !string.IsNullOrEmpty(transactionHeroSearchModel.end_date) ? DateTime.Parse(transactionHeroSearchModel.end_date).AddDays(1) : null;
            var qr = _transactionHeroRepo.GetAllHeroRepo();
            List<TransactionHeroResultModel> lst = new List<TransactionHeroResultModel>();
            var listData = qr.Where(x => (string.IsNullOrEmpty(transactionHeroSearchModel.start_date) || x.Date_Sell >= _start)
                                                && (string.IsNullOrEmpty(transactionHeroSearchModel.end_date) || x.Date_Sell < _end) && x.Type == "Hero").Select(x => new TransactionHeroResultModel()
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
            lst = listData.Skip(transactionHeroSearchModel.StartNumber).Take(transactionHeroSearchModel.PageSize).ToList();
            var data = new TransactionHeroRsModel()
            {
                Data = lst,
                Count = listData.Count(),
            };
            return data;
            //var data = new List<Object> { lst, listData.Count() };
            //return data;
        }
    }
}
