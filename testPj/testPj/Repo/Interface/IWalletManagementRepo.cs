using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Models;

namespace testPj.Repo.Interface
{
    public interface IWalletManagementRepo
    {
        List<WalletManagement> GetAll();
        Task<bool> CreateWallet(WalletManagement walletManagement);
        Task<bool> UpdateWallet(WalletManagement walletManagement);
        Task<bool> CheckedWallet(WalletManagement walletManagement);
        public WalletManagement GetDetailWallet(int id);
        Task<bool> DeleteWalletRP(WalletManagement walletManagement);
        List<WalletManagement> CheckWalletManagement(string AddressWallet);
    }
}
