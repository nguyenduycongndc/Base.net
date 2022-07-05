using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Repo.Interface;

namespace testPj.Repo
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

        public List<TransactionHistory> GetAllSell()
        {
            return _context.TransactionHistory.ToList();
        }
    }
}
