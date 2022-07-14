using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Data;
using ToolMM.Repo.Interface;

namespace ToolMM.Repo
{
    public class TransactionNFTRepo : ITransactionNFTRepo
    {
        private readonly SqlDbContext _context;

        public TransactionNFTRepo(SqlDbContext context)
        {
            _context = context;
        }
        public List<TransactionHistory> GetAllRepo()
        {
            return _context.TransactionHistory.ToList();
        }
        //public List<TransactionHistory> GetAllHeroRepo()
        //{
        //    return _context.TransactionHistory.ToList();
        //}
    }
}
