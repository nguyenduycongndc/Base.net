﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Models;

namespace testPj.Services.Interface
{
    public interface IUserService
    {
        List<UserModel> GetAllUser();
        public CurrentUserModel GetDetailModels(int id);
        public Task<bool> CreateUse(CreateModel input, CurrentUserModel _userInfo);
        public Task<bool> UpdateUse(UpdateModel input, CurrentUserModel _userInfo);
        public Task<bool> DeleteUse(int Id, CurrentUserModel _userInfo);
    }
}
