using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Models;

namespace ToolMM.Services.Interface
{
    public interface IWalletManagementService
    {
        WalletRsModel GetAllWallet(SearchWalletModel searchWalletModel);
        public Task<bool> CreateWallet(CreateWalletModel input, CurrentUserModel _userInfo);
        public Task<bool> CheckedWallet(CheckedWalletModel input, CurrentUserModel _userInfo);
        public DetailWalletModel GetDetailModels(int id);
        public Task<bool> DeleteWallet(int Id, CurrentUserModel _userInfo);

    }
}
