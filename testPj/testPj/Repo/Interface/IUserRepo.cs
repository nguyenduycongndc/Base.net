using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Models;

namespace testPj.Repo.Interface
{
    public interface IUserRepo
    {
        List<User> GetAll();
        public User GetDetail(int id);
        Task<bool> CreateUs(User user);
        Task<bool> UpdateUs(User user);
        Task<bool> DeleteUs(User user);
        User GetDetailByName(InputLoginModel inputModel);
    }
}
