﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Models;

namespace testPj.Services.Interface
{
    public interface ILoginService
    {
        public LoginModel Login(InputLoginModel inputModel);
    }
}
