using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Models;

namespace testPj.Services.Interface
{
    public interface IBuysService
    {
        public Task<bool> CreateData(InputBuyModel inputBuyModel, CurrentUserModel _userInfo);
        List<BuysModel> GetAllListBuy();
        public Task<bool> DeleteListBuy(int Id);
    }
}
