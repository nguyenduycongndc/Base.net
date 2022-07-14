using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Data;

namespace ToolMM.Repo.Interface
{
    public interface IBuysRepo
    {
        Task<bool> CreateDataRepo(InputToolBuy inputToolBuy);
        List<InputToolBuy> GetAll();
        public InputToolBuy GetDetailBuy(int id);
        Task<bool> DeleteBuy(InputToolBuy inputToolBuy);
    }
}
