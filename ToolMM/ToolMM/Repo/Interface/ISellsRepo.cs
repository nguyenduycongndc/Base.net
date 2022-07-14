﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolMM.Data;

namespace ToolMM.Repo.Interface
{
    public interface ISellsRepo
    {
        List<WalletManagement> GetAll();
        Task<bool> CreateTransactionHistory(TransactionHistory transactionHistory);
        Task<bool> UpdateHistory(TransactionHistory transactionHistory);
        List<TransactionHistory> GetAllSell();
        public TransactionHistory GetHTDetail(int id);
    }
}
