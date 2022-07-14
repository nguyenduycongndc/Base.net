using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Data;
using ToolMM.Repo.Interface;

namespace ToolMM.Repo
{
    public class TransactionHeroRepo : ITransactionHeroRepo
    {
        private readonly SqlDbContext _context;

        public TransactionHeroRepo(SqlDbContext context)
        {
            _context = context;
        }
        public List<TransactionHistory> GetAllHeroRepo()
        {
            return _context.TransactionHistory.ToList();
        }
    }
}
