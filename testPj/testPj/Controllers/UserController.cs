﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PagedList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Models;
using testPj.Repo.Interface;
using testPj.Services;
using testPj.Services.Interface;

namespace testPj.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService loginService;

        public UserController(ILogger<UserController> logger, IUserService loginService)
        {
            _logger = logger;
            this.loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult listUser()
        {
            List<UserModel> lst = loginService.GetAllUser();
            return PartialView("listUser", lst.ToPagedList(1, 10));
        }
        
        [HttpGet]
        public List<UserModel> GetAll()
        {
            var testList = loginService.GetAllUser();
            return testList;
        }
        public PartialViewResult LoadUser(int id)
        {
            try
            {
                var edt = loginService.GetDetailModels(id);
                return PartialView("DetailUser", edt);
            }
            catch
            {
                return PartialView("DetailUser", new DetailModel());
            }
        }
        [HttpGet]
        [Route("Detail")]
        public DetailModel Detail(int id)
        {
            try
            {
                var testDetail = loginService.GetDetailModels(id);
                return testDetail;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        [HttpPost]
        [Route("CreateUser")]
        public async Task<bool> Create([FromBody] CreateModel add)
        {
            try
            {
                return await loginService.CreateUse(add);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<bool> Update([FromBody] UpdateModel update)
        {
            try
            {
                return await loginService.UpdateUse(update);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<bool> Delete(int id)
        {
            try
            {
                return await loginService.DeleteUse(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
