using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Models;

namespace testPj.Services.Interface
{
    public interface ILoginService
    {
        //List<UserModel> GetAllUser();
        //public DetailModel GetDetailModels(int id);
        //public Task<bool> CreateUse(CreateModel input);
        //public Task<bool> UpdateUse(UpdateModel input);
        //public Task<bool> DeleteUse(int Id);
        public LoginModel Login(InputLoginModel inputModel);
    }
}
