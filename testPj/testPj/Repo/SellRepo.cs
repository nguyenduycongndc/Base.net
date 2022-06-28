using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Repo.Interface;

namespace testPj.Repo
{
    public class SellRepo : ISellRepo
    {
        private readonly SqlDbContext _context;
        public SellRepo(SqlDbContext context)
        {
            _context = context;
        }
        public List<WalletManagement> GetAll()
        {
            return _context.WalletManagements.ToList();
        }
    }
}
