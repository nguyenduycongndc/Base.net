using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testPj.Attributes;
using testPj.Models;

namespace testPj.Controllers
{
    [Route("[controller]")]
    //[ApiController]
    [BaseAuthorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Items["UserInfo"] is not CurrentUserModel _userInfo)
            {
                return null;
            }
            return View();
        }
    }
}
