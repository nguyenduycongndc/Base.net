using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using testPj.Models;
using testPj.Services.Interface;

namespace testPj.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService loginServices;

        public LoginController(ILogger<LoginController> logger, ILoginService loginServices)
        {
            _logger = logger;
            _logger.LogError("test");
            this.loginServices = loginServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public LoginModel LoginRevamp([FromBody] InputLoginModel inputModel)
        {
            var testList = loginServices.Login(inputModel);
            return testList;
        }
        public static string EncodeServerName(string serverName)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(serverName));
        }
    }
}
