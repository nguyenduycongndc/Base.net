using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Repo.Interface;
using ToolMM.Services.Interface;
using static ToolMM.Models.StatisticalModel;

namespace ToolMM.Services
{
    public class StatisticalService : IStatisticalService
    {
        private readonly ILogger<StatisticalService> _logger;
        private readonly IStatisticalRepo _statisticalRepo;
        public StatisticalService(IStatisticalRepo statisticalRepo, ILogger<StatisticalService> logger)
        {
            _statisticalRepo = statisticalRepo;
            _logger = logger;
        }
        public StatisticalRsModel GetAllStatistical(SearchStatisticalModel searchStatisticalModel)
        {
            DateTime? _start = !string.IsNullOrEmpty(searchStatisticalModel.start_date) ? DateTime.Parse(searchStatisticalModel.start_date) : null;
            DateTime? _end = !string.IsNullOrEmpty(searchStatisticalModel.end_date) ? DateTime.Parse(searchStatisticalModel.end_date).AddDays(1) : null;
            var qr = _statisticalRepo.GetAllStatistical();
            List<StatisticalInputSearchModel> lst = new List<StatisticalInputSearchModel>();
            var list = qr.Where(x => (x.AddressWallet.Contains(searchStatisticalModel.Wallet) || string.IsNullOrEmpty(searchStatisticalModel.Wallet))
                                          && (string.IsNullOrEmpty(searchStatisticalModel.start_date) || x.Date_Sell >= _start)
                                                && (string.IsNullOrEmpty(searchStatisticalModel.end_date) || x.Date_Sell < _end)
                                                ).Select(x => new StatisticalInputSearchModel()
                                                {
                                                    Id = x.Id,
                                                    IdNFT = x.IdNFT,
                                                    Wallet = x.AddressWallet,
                                                    Rarity = x.rarity,
                                                    Class = x.Class,
                                                    Date = x.Date_Sell.HasValue ? x.Date_Sell.Value.ToString("dd/MM/yyy HH:mm:ss") : "",
                                                    BuyPrice = x.Buy_TAU,
                                                    SellPrice = x.Sell_TAU,
                                                    Profit = (x.Sell_TAU - x.Buy_TAU),
                                                }).OrderBy(x => x.Id).ToList();
            var count = list.Count();
            lst = list.Skip(searchStatisticalModel.StartNumber).Take(searchStatisticalModel.PageSize).ToList();
            var data = new StatisticalRsModel()
            {
                Data = lst,
                Count = list.Count(),
            };
            return data;
            //var data = new List<Object> { lst, list.Count() };
            //return data;
        }
    }
}
