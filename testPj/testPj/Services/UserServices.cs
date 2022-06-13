﻿using Microsoft.EntityFrameworkCore;
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
            }).OrderBy(x => x.Id).ToList();
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
        public async Task<bool> CreateUse(CreateModel input, CurrentUserModel _userInfo)
        {
            try
            {
                var checkUser = userRepo.CheckUser(input.UserName);
                if (checkUser != null)
                {
                    _logger.LogError("Tài khoản đã tồn tại");
                    return false;
                }
                //string salt = "";
                //string hashedPassword = "";
                //if (input != null)
                //{
                //    var pass = input.Password;
                //    salt = Crypto.GenerateSalt(); // salt key
                //    var password = input.Password + salt;
                //    hashedPassword = Crypto.HashPassword(password);
                //}
                string salt = "";
                string hashedPassword = "";
                salt = Crypto.GenerateSalt(); // salt key
                var password = input.Password/* + salt*/;
                hashedPassword = EncodeServerName(password);
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
                    CreatedBy = _userInfo.Id,
                };
                var _userrole = new UsersRoles
                {
                    roles_id = input.RoleId,
                    Users = us
                };
                return await userRepo.CreateUs(us, _userrole);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public async Task<bool> UpdateUse(UpdateModel input, CurrentUserModel _userInfo)
        {
            try
            {
                var checkUser = userRepo.CheckUser(input.UserName);
                if (checkUser.Count() > 1)
                {
                    _logger.LogError("Tài khoản đã tồn tại");
                    return false;
                }
                var data = userRepo.GetDetail(input.Id);
                if (data == null) return false;
                data.Id = input.Id;
                data.UserName = input.UserName.ToLower();
                data.Email = input.Email.ToLower().Trim();
                data.IsActive = input.IsActive;
                data.ModifiedAt = DateTime.Now;
                data.ModifiedBy = _userInfo.Id;
                return await userRepo.UpdateUs(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteUse(int id, CurrentUserModel _userInfo)
        {
            try
            {
                var data = userRepo.GetDetail(id);
                if (data == null) return false;
                data.DeletedAt = DateTime.Now;
                data.DeletedBy = _userInfo.Id;
                data.IsDeleted = 0;
                return await userRepo.DeleteUs(data);
            }
            catch (Exception ex)
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
