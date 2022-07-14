using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Models;

namespace ToolMM.Services.Interface
{
    public interface ISellsService
    {
        List<WalletModel> GetAllWallet();
        public Task<bool> CreateHistory(BuysActiveModel buysActiveModel);
        List<WalletModel> GetAllWalletDrop(string q);
        SellRsDataModel GetDataSell(SearchSellModel searchSellModel);
        List<SellModel> GetListDataSell(ChooseAll obj);
        List<SellRsModel> GetListDataFESell(ChooseAll obj);
        public Task<bool> UpdateHistory(SellActiveModel sellActiveModel);
        public SellRsModel GetDetailModels(int id);
    }
}
