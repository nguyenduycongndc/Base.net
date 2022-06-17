using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Models;
using testPj.Repo;
using testPj.Repo.Interface;
using testPj.Services.Interface;

namespace testPj.Services
{
    public class WalletManagementService : IWalletManagementService
    {
        //private readonly ILogger<WalletManagementService> _logger;
        //private readonly IWalletManagementRepo _walletManagementRepo;
        //public WalletManagementService(IWalletManagementRepo walletManagementRepo, ILogger<WalletManagementService> logger)
        //{
        //    _walletManagementRepo = walletManagementRepo;
        //    _logger = logger;
        //}
        //public List<Object> GetAllWallet(SearchWalletModel searchWalletModel)
        //{
        //    //var qr = WalletManagementRepo.GetAll();
        //    //List<WalletModel> lst = new List<WalletModel>();
        //    //var listWallet = qr.Where(x => (x.IsDelete != 0)).Select(x => new WalletModel()
        //    //                              {
        //    //                                  Id = x.Id,
        //    //                                  Address = x.Address,
        //    //                                  TAU = x.TAU,
        //    //                                  BNB = x.BNB,
        //    //                                  Selected = x.Selected,
        //    //                              }).OrderBy(x => x.Id).ToList();
        //    //var count = listWallet.Count();
        //    //var countSelected = qr.Where(x => (x.IsDelete != 0)).Count(a => a.Selected == 1);
        //    //var countNoSelected = qr.Where(x => (x.IsDelete != 0)).Count(a => a.Selected == 0);
        //    //lst = listWallet.Skip(searchWalletModel.StartNumber).Take(searchWalletModel.PageSize).ToList();
        //    //var data = new List<Object> { lst, listWallet.Count(), countSelected, countNoSelected };
        //    //return data;
        //    return null;
        //}
    }
}
