using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Data;

namespace ToolMM.Repo.Interface
{
    public interface ITransactionHeroRepo
    {
        List<TransactionHistory> GetAllHeroRepo();
    }
}
