using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;

namespace testPj.Repo.Interface
{
    public interface ISellRepo
    {
        List<WalletManagement> GetAll();
    }
}
