using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Controllers;
using testPj.DataAccess;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using testPj.Models;
using testPj.Configs;
using testPj.Services;
using testPj.Services.Interface;

namespace testPj.Attributes
{
    public class BaseAuthorize : Attribute, IAuthorizationFilter
    {
        private string _role;
        private string _rule;
        private string _userInfoPrex = "Auth.UserInfo.{0}";
        private readonly IConfiguration _config;
        private readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
        public BaseAuthorize()
        {
        }
        public BaseAuthorize(IConfiguration config, string role, string rule)
        {
            _config = config;
            _rule = rule;
            _role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool hasAllowAnonymousAttribute = false;

            if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
            {
                var actionAttributes = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true);
                foreach (var item in actionAttributes)
                {
                    if (item is AllowAnonymousAttribute)
                    {
                        hasAllowAnonymousAttribute = true;
                        break;
                    }
                }
            }
            if (!hasAllowAnonymousAttribute)
            {
                var Secret = ((IConfiguration)context.HttpContext.RequestServices
                    .GetService(typeof(IConfiguration)))["Jwt:Key"];
                //var iCache = ((IConnectionMultiplexer)context.HttpContext.RequestServices
                //       .GetService(typeof(IConnectionMultiplexer)));

                ////var iLogger = ((ILoggerManager)context.HttpContext.RequestServices
                ////       .GetService(typeof(ILoggerManager)));

                //if (!iCache.IsConnected)
                //    context.Result = new JsonResult(new { message = "Unable to connect to redis server." }) { StatusCode = StatusCodes.Status500InternalServerError };

                //var redisDb = iCache.GetDatabase();

                var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                var jwtToken = JwtTokenCm.GetTokenInfo(token, Secret);
                if (jwtToken == null)
                {
                    _logger.Log(NLog.LogLevel.Error, $"{token}: Unauthorized: Access denied!");
                    context.Result = new JsonResult(new { message = "Unauthorized: token's invalid" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }
                var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
                if (userId == null)
                {
                    _logger.Log(NLog.LogLevel.Error, $"{token}: UserId is null");
                    context.Result = new JsonResult(new { message = "UserId is null" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }

                //string userInfoJson = redisDb.StringGet(String.Format(_userInfoPrex, userId));
                //if (string.IsNullOrEmpty(userInfoJson))
                //{
                //    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                //    return;
                //}

                var userServices = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as UserServices;
                var user = userServices.GetDetailModels(int.Parse(userId));
                //var user = JsonSerializer.Deserialize<CurrentUserModel>(userInfoJson);

                if (user == null)
                {
                    //iLogger.LogError($"{userId}: Unauthorized: Access denied!");
                     _logger.Log(NLog.LogLevel.Error, $"{userId}: Unauthorized: Access denied!");
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }
                if (!string.IsNullOrEmpty(_role))
                {
                    var rls = jwtToken.Claims.First(x => x.Type == "roles").Value;
                    var ar = rls.Split(',');
                    if (string.IsNullOrEmpty(rls) || !ar.Contains(_role))
                    {
                         _logger.Log(NLog.LogLevel.Error, $"{userId}: Unauthorized: Access denied!");
                        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(_rule))
                {
                    var rls = jwtToken.Claims.First(x => x.Type == "rules").Value;
                    var ar = rls.Split(',');
                    if (string.IsNullOrEmpty(rls) || !ar.Contains(_rule))
                    {
                         _logger.Log(NLog.LogLevel.Error, $"{userId}: Unauthorized: Access denied!");
                        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                        return;
                    }
                }
                context.HttpContext.Items["UserInfo"] = user;
                _logger.Log(NLog.LogLevel.Info, $"{user.UserName}: logon into api successfully!");
            }
        }
    }
}
