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
using testPj.Attributes;
using testPj.Models;
using testPj.Services.Interface;

namespace testPj.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly ILoginService loginServices;

        public LoginController(ILogger<LoginController> logger, ILoginService loginServices)
        {
            _logger = logger;
            this.loginServices = loginServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("LoginRevamp")]
        public LoginModel LoginRevamp([FromBody] InputLoginModel inputModel)
        {
            var testList = loginServices.Login(inputModel);
            return testList;
        }
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Login");
        }
    }
}
