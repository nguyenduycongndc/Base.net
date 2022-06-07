using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Models;
using testPj.Repo.Interface;

namespace testPj.Repo
{
    public class LoginRepo : ILoginRepo
    {
        private readonly PostgresContext context;

        public LoginRepo(PostgresContext context)
        {
            this.context = context;
        }
        public List<Role> GetAll()
        {
            return context.Role.ToList();
        }
        public Role GetDetail(int id)
        {
            var query = (from x in context.Role
                         where x.Id.Equals(id)
                         select new Role
                         {
                             Id = x.Id,
                             UserName = x.UserName,
                             PassWord = x.PassWord,
                             IsActive = x.IsActive,
                         }).FirstOrDefault();

            return query;
        }
        public async Task<bool> CreateUs(Role Role)
        {
            await context.Role.AddAsync(Role);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateUs(Role Role)
        {
            var updt = await context.Role.FindAsync(Role.Id);
            updt.Id = Role.Id;
            updt.UserName = Role.UserName;
            updt.PassWord = Role.PassWord;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUs(Role Role)
        {
            var updt = await context.Role.FindAsync(Role.Id);
            updt.Id = Role.Id;
            updt.IsActive = false;
            await context.SaveChangesAsync();
            return true;
        }

        public Role GetDetailByName(InputLoginModel inputModel)
        {
            var query = (from x in context.Role
                         where x.UserName.Equals(inputModel.UserName)
                         select new Role
                         {
                             Id = x.Id,
                             UserName = x.UserName,
                             Token = x.Token,
                             PassWord = x.PassWord,
                             IsActive = x.IsActive,
                         }).FirstOrDefault();

            return query;
        }
    }
}
