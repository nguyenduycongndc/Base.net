using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Models;

namespace ToolMM.Services.Interface
{
    public interface ITransactionNFTService
    {
        TransactionHeroRsModel GetAllHeroService(TransactionSearchModel transactionSearchModel);
        TransactionItemRsModel GetAllItemService(TransactionSearchModel transactionSearchModel);
        TransactionTicketRsModel GetAllTicketService(TransactionSearchModel transactionSearchModel);
        TransactionPackRsModel GetAllPackService(TransactionSearchModel transactionSearchModel);
        TransactionEggRsModel GetAllEggService(TransactionSearchModel transactionSearchModel);

    }
}
