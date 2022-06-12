using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using testPj.Data;
using testPj.Models;
using testPj.Repo.Interface;
using testPj.Services.Interface;

namespace testPj.Services
{
    public class UserServices : IUserService
    {
        private readonly ILogger<UserServices> _logger;
        private readonly IUserRepo userRepo;
        public UserServices(IUserRepo userRepo, ILogger<UserServices> logger)
        {
            this.userRepo = userRepo;
            _logger = logger;
        }

        public List<UserModel> GetAllUser()
        {
            var qr = userRepo.GetAll();
            List<UserModel> lst = new List<UserModel>();
            var listUser = qr.Where(x => x.IsActive.Equals(1)).Select(x => new UserModel()
            { 
                Id = x.Id,
                Name = x.UserName,
                Password = x.Password,
                IsActive = x.IsActive,
            }).OrderBy(x=>x.Id).ToList();
            lst = listUser;
            return lst;
        }
        public CurrentUserModel GetDetailModels(int Id)
        {
            try
            {
                var data = userRepo.GetDetail(Id);

                var detailUs = new CurrentUserModel()
                {
                    Id = data.Id,
                    UserName = data.UserName,
                    FullName = data.UserName,
                    IsActive = data.IsActive,
                    RoleId = data.RoleId,
                };

                return detailUs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        public async Task<bool> CreateUse(CreateModel input)
        {
            try
            {
                string salt = "";
                string hashedPassword = "";
                if (input != null)
                {
                    var pass = input.Password;
                    salt = Crypto.GenerateSalt(); // salt key
                    var password = input.Password + salt;
                    hashedPassword = Crypto.HashPassword(password);
                }
                Users us = new Users()
                {
                    FullName = input.UserName.Trim(),
                    UserName = input.UserName.ToLower(),
                    Password = hashedPassword,
                    IsActive = 1,
                    DateOfJoining = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    SaltKey = salt,
                    RoleId = input.RoleId,
                };
                var _userrole = new UsersRoles
                {
                    roles_id = input.RoleId,
                    Users = us
                };
                return await userRepo.CreateUs(us, _userrole);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
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
                data.UserName = input.UserName.ToLower();
                data.Email = input.Email.ToLower().Trim();
                data.IsActive = input.IsActive;
                return await userRepo.UpdateUs(data);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteUse(int id)
        {
            try
            {
                var data = userRepo.GetDetail(id);
                if (data == null) return false;
                return await userRepo.DeleteUs(data);
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public static string EncodeServerName(string serverName)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(serverName));
        }
    }
}
