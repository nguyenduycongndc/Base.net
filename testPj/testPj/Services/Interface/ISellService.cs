using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Models;

namespace testPj.Services.Interface
{
    public interface ISellService
    {
        List<WalletModel> GetAllWallet();
        List<WalletModel> GetAllWalletDrop(string q);
    }
}
