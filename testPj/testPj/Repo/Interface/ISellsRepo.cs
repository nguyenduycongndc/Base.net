using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;

namespace testPj.Repo.Interface
{
    public interface ISellsRepo
    {
        List<WalletManagement> GetAll();
        Task<bool> CreateTransactionHistory(TransactionHistory transactionHistory);
        Task<bool> UpdateHistory(TransactionHistory transactionHistory);
        List<TransactionHistory> GetAllSell();
        TransactionHistory GetHTDetail(int id);
    }
}
