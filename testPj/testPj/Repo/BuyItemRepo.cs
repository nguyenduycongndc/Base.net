using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Models;
using testPj.Repo.Interface;

namespace testPj.Repo
{
    public class BuyItemRepo : IBuyItemRepo
    {
        private readonly SqlDbContext _context;
        public BuyItemRepo(SqlDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateDataRepo(InputToolBuy inputToolBuy)
        {
            await _context.InputToolBuy.AddAsync(inputToolBuy);
            await _context.SaveChangesAsync();
            return true;
        }
        public InputToolBuy GetDetailBuy(int id)
        {
            var query = (from x in _context.InputToolBuy
                         where x.Id.Equals(id)
                         select new InputToolBuy
                         {
                             Id = x.Id,
                             CreatedAt = x.CreatedAt,
                             CreatedBy = x.CreatedBy,
                             IsActive = x.IsActive,
                         }).FirstOrDefault();

            return query;
        }
        public List<InputToolBuy> GetAll()
        {
            return _context.InputToolBuy.ToList();
        }
        public async Task<bool> DeleteBuy(InputToolBuy inputToolBuy)
        {
            var updt = await _context.InputToolBuy.FindAsync(inputToolBuy.Id);
            updt.Id = inputToolBuy.Id;
            updt.IsActive = 0;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
