using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Models;

namespace testPj.Repo.Interface
{
    public interface ILoginRepo
    {
        List<Role> GetAll();
        public Role GetDetail(int id);
        Task<bool> CreateUs(Role role);
        Task<bool> UpdateUs(Role role);
        Task<bool> DeleteUs(Role role);
        Role GetDetailByName(InputLoginModel inputModel);
    }
}
