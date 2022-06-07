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
        private readonly PostgresContext context;

        public UserRepo(PostgresContext context)
        {
            this.context = context;
        }
        public List<User> GetAll()
        {
            return context.User.ToList();
        }
        public User GetDetail(int id)
        {
            var query = (from x in context.User
                         where x.Id.Equals(id)
                         select new User
                         {
                             Id = x.Id,
                             Name = x.Name,
                             Password = x.Password,
                             IsActive = x.IsActive,
                         }).FirstOrDefault();

            return query;
        }
        public async Task<bool> CreateUs(User user)
        {
            await context.User.AddAsync(user);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateUs(User user)
        {
            var updt = await context.User.FindAsync(user.Id);
            updt.Id = user.Id;
            updt.Name = user.Name;
            updt.Password = user.Password;
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUs(User user)
        {
            var updt = await context.User.FindAsync(user.Id);
            updt.Id = user.Id;
            updt.IsActive = 0;
            await context.SaveChangesAsync();
            return true;
        }
    }
}
