using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Models;

namespace ToolMM.Services.Interface
{
    public interface ITransactionHeroService
    {
        TransactionHeroRsModel GetAllHeroService(TransactionHeroSearchModel transactionHeroSearchModel);

    }
}
