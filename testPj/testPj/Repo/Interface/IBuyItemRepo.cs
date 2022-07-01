using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;

namespace testPj.Repo.Interface
{
    public interface IBuyItemRepo
    {
        Task<bool> CreateDataRepo(InputToolBuy inputToolBuy);
        List<InputToolBuy> GetAll();
        public InputToolBuy GetDetailBuy(int id);
        Task<bool> DeleteBuy(InputToolBuy inputToolBuy);
    }
}
