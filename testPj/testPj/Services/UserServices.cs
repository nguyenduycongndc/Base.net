using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Models;
using testPj.Repo.Interface;
using testPj.Services.Interface;

namespace testPj.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepo userRepo;
        public UserServices(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public List<UserModel> GetAllUser()
        {
            var qr = userRepo.GetAll();
            List<UserModel> lst = new List<UserModel>();
            var listUser = qr.Where(x => x.IsActive.Equals(1)).Select(x => new UserModel()
            //var listUser = qr.Select(x => new LoginModel()  
            { 
                Id = x.Id,
                Name = x.Name,
                Password = x.Password,
                IsActive = x.IsActive,
            }).OrderBy(x=>x.Id).ToList();
            lst = listUser;
            return lst;
        }
        public DetailModel GetDetailModels(int Id)
        {
            try
            {
                var data = userRepo.GetDetail(Id);

                var detailUs = new DetailModel()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Password = data.Password,
                    IsActive = data.IsActive,
                };

                return detailUs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<bool> CreateUse(CreateModel input)
        {
            try
            {
                User us = new User()
                {
                    Name = input.Name,
                    Password = input.Password,
                    IsActive = 1,
                };
                
                return await userRepo.CreateUs(us);
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateUse(UpdateModel input)
        {
            try
            {
                var data = userRepo.GetDetail(input.Id);
                if (data == null) return false;
                data.Id = input.Id;
                data.Name = input.Name;
                data.Password = input.Password;
                return await userRepo.UpdateUs(data);
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteUse(int Id)
        {
            try
            {
                var data = userRepo.GetDetail(Id);
                if (data == null) return false;
                //data.Id = Id;
                //data.IsActive = 0;
                return await userRepo.DeleteUs(data);
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
