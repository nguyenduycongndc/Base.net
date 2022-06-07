using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testPj.Models;
using testPj.Services.Interface;

namespace testPj.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService loginServices;

        public LoginController(ILoginService loginServices)
        {
            this.loginServices = loginServices;
        }

        public IActionResult Index()
        {
            //loginServices.Login("a", "");

            return View();
        }
        [HttpPost]
        public LoginModel Login(InputLoginModel inputModel)
        {
            var test = new InputLoginModel
            {
                UserName = "a",
                PassWord = "123"
            };


            var testList = loginServices.Login(test);
            //var testList = loginServices.Login(inputModel);
            return testList;
        }
        public static string EncodeServerName(string serverName)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(serverName));
        }
    }
}
