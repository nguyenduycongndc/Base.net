using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Models;
using testPj.Repo.Interface;

namespace testPj.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly SqlDbContext context;

        public UserRepo(SqlDbContext context)
        {
            this.context = context;
        }
        public List<Users> GetAll()
        {
            return context.Users.ToList();
        }
        public Users GetDetail(int id)
        {
            var query = (from x in context.Users
                         where x.Id.Equals(id)
                         select new Users
                         {
                             Id = x.Id,
                             UserName = x.UserName,
                             Password = x.Password,
                             IsActive = x.IsActive,
                         }).FirstOrDefault();

            return query;
        }
        public async Task<bool> CreateUs(Users user, UsersRoles usersRoles)
        {
            await context.Users.AddAsync(user);
            await context.UsersRoles.AddAsync(usersRoles);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateUs(Users user)
        {
            var updt = await context.Users.FindAsync(user.Id);
            updt.Id = user.Id;
            updt.UserName = user.UserName;
            updt.Password = user.Password;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUs(Users user)
        {
            var updt = await context.Users.FindAsync(user.Id);
            updt.Id = user.Id;
            updt.IsActive = 0;
            await context.SaveChangesAsync();
            return true;
        }
        public Users GetDetailByName(InputLoginModel inputModel)
        {
            var query = (from x in context.Users
                         where x.UserName.Equals(inputModel.UserName)
                         select new Users
                         {
                             Id = x.Id,
                             UserName = x.UserName,
                             Password = x.Password,
                             IsActive = x.IsActive,
                         }).FirstOrDefault();

            return query;
        }
    }
}
