using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Models;
using testPj.Repo.Interface;

namespace testPj.Repo
{
    public class WalletManagementRepo : IWalletManagementRepo
    {
        private readonly SqlDbContext _context;
        public WalletManagementRepo(SqlDbContext context)
        {
            _context = context;
        }
        public List<WalletManagement> GetAll()
        {
            return _context.WalletManagements.ToList();
        }
        public async Task<bool> CreateWallet(WalletManagement walletManagement)
        {
            await _context.WalletManagements.AddAsync(walletManagement);
            await _context.SaveChangesAsync();
            return true;
        }
        public WalletManagement GetDetailWallet(int id)
        {
            var query = (from x in _context.WalletManagements
                         where x.Id.Equals(id)
                         select new WalletManagement
                         {
                             Id = x.Id,
                             PrivateKey = x.PrivateKey,
                             AddressWallet = x.AddressWallet,
                             TAU = x.TAU,
                             BNB = x.BNB,
                             IsCheck = x.IsCheck,
                             CreatedAt = x.CreatedAt,
                             CreatedBy = x.CreatedBy,
                             ModifiedAt = x.ModifiedAt,
                             ModifiedBy = x.ModifiedBy,
                             IsDeleted = x.IsDeleted,
                             DeletedAt = x.DeletedAt,
                             DeletedBy = x.DeletedBy,
                             IsActive = x.IsActive,
                             users_id = x.users_id,
                         }).FirstOrDefault();

            return query;
        }
        public async Task<bool> CheckedWallet(WalletManagement walletManagement)
        {
            var updt = await _context.WalletManagements.FindAsync(walletManagement.Id);
            updt.Id = walletManagement.Id;
            updt.IsCheck = walletManagement.IsCheck;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteWalletRP(WalletManagement walletManagement)
        {
            var updt = await _context.WalletManagements.FindAsync(walletManagement.Id);
            updt.Id = walletManagement.Id;
            updt.IsActive = 0;
            updt.DeletedAt = walletManagement.DeletedAt;
            updt.DeletedBy = walletManagement.DeletedBy;
            updt.IsDeleted = 1;
            await _context.SaveChangesAsync();
            return true;
        }
        public List<WalletManagement> CheckWalletManagement(string AddressWallet)
        {
            var query = (from x in _context.WalletManagements
                         where x.AddressWallet.Equals(AddressWallet) &&  x.IsDeleted != 1 
                         select new WalletManagement
                         {
                             Id = x.Id,
                             PrivateKey = x.PrivateKey,
                             AddressWallet = x.AddressWallet,
                             IsActive = x.IsActive,
                             TAU = x.TAU,
                             BNB = x.BNB,
                             IsCheck = x.IsCheck,
                             IsDeleted = x.IsDeleted,
                         }).ToList();

            return query;
        }
        public async Task<bool> UpdateWallet(WalletManagement walletManagement)
        {
            var updt = await _context.WalletManagements.FindAsync(walletManagement.Id);
            updt.Id = walletManagement.Id;
            updt.PrivateKey = walletManagement.PrivateKey;
            updt.AddressWallet = walletManagement.AddressWallet;
            updt.BNB = walletManagement.BNB;
            updt.TAU = walletManagement.TAU;
            updt.IsActive = walletManagement.IsActive;
            updt.ModifiedAt = walletManagement.ModifiedAt;
            updt.ModifiedBy = walletManagement.ModifiedBy;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
