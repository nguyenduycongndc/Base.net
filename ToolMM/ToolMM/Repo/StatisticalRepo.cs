using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Data;
using ToolMM.Repo.Interface;

namespace ToolMM.Repo
{
    public class StatisticalRepo : IStatisticalRepo
    {
        private readonly SqlDbContext _context;

        public StatisticalRepo(SqlDbContext context)
        {
            _context = context;
        }
        public List<TransactionHistory> GetAllStatistical()
        {
            return _context.TransactionHistory.ToList();
        }
    }
}
