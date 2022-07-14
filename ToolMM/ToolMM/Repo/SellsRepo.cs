using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Data;
using ToolMM.Repo.Interface;

namespace ToolMM.Repo
{
    public class SellsRepo : ISellsRepo
    {
        private readonly SqlDbContext _context;
        public SellsRepo(SqlDbContext context)
        {
            _context = context;
        }
        public List<WalletManagement> GetAll()
        {
            return _context.WalletManagements.ToList();
        }
        public async Task<bool> CreateTransactionHistory(TransactionHistory transactionHistory)
        {
            await _context.TransactionHistory.AddAsync(transactionHistory);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateHistory(TransactionHistory transactionHistory)
        {
            var updt = await _context.TransactionHistory.FindAsync(transactionHistory.Id);
            updt.Id = transactionHistory.Id;
            updt.IdNFT = transactionHistory.IdNFT;
            updt.Class = transactionHistory.Class;
            updt.rarity = transactionHistory.rarity;
            updt.AddressWallet = transactionHistory.AddressWallet;
            updt.TAU = transactionHistory.TAU;
            updt.BNB = transactionHistory.BNB;
            updt.USD = transactionHistory.USD;
            updt.Sell_TAU = transactionHistory.Sell_TAU;
            updt.Date_Sell = transactionHistory.Date_Sell;
            updt.Is_Selling = transactionHistory.Is_Selling;
            updt.IsCheck = transactionHistory.IsCheck;
            updt.Token_Id = transactionHistory.Token_Id;
            updt.IsActive = transactionHistory.IsActive;
            updt.Fee = transactionHistory.Fee;

            await _context.SaveChangesAsync();
            return true;
        }
        public List<TransactionHistory> GetAllSell()
        {
            return _context.TransactionHistory.ToList();
        }
        public TransactionHistory GetHTDetail(int id)
        {
            var query = (from x in _context.TransactionHistory
                         where x.Id.Equals(id)
                         select new TransactionHistory
                         {
                             Id = x.Id,
                             IdNFT = x.IdNFT,
                             Class = x.Class,
                             rarity = x.rarity,
                             AddressWallet = x.AddressWallet,
                             TAU = x.TAU,
                             BNB = x.BNB,
                             USD = x.USD,
                             Sell_TAU = x.Sell_TAU,
                             Buy_TAU = x.Buy_TAU,
                             Date_Sell = x.Date_Sell,
                             Date_Buy = x.Date_Buy,
                             Is_Selling = x.Is_Selling,
                             IsCheck = x.IsCheck,
                             Token_Id = x.Token_Id,
                             IsActive = x.IsActive,
                         }).FirstOrDefault();

            return query;
        }
    }
}
