using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToolMM.Data;
using ToolMM.Models;
using ToolMM.Repo.Interface;
using ToolMM.Tool.ControllerTool;

namespace ToolMM.Repo
{
    public class BuysRepo : IBuysRepo
    {
        private readonly IWorker _worker;
        private readonly SqlDbContext _context;
        public BuysRepo(SqlDbContext context)
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
