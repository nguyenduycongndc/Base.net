using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using testPj.Data;
using testPj.Models;
using testPj.Repo.Interface;
using testPj.Services.Interface;

namespace testPj.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILogger<LoginService> _logger;
        private readonly IUserRepo loginRepo;

        public LoginService(ILogger<LoginService> logger, IUserRepo loginRepo)
        {
            _logger = logger;
            this.loginRepo = loginRepo;
        }
        public LoginModel Login(InputLoginModel inputModel)
        {

            try
            {
                LoginModel userdetai = null;
                if (inputModel.UserName != "" && inputModel.UserName != null && inputModel.PassWord != "" && inputModel.PassWord != null)
                {
                    var user = loginRepo.GetDetailByName(inputModel);

                    userdetai = new LoginModel()
                    {
                        UserName = user.UserName,
                        Token = GenerateJwt(user),
                    };
                }
                return userdetai;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public string GenerateJwt(Users user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            DateTime jwtDate = DateTime.UtcNow;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Design By Congnd"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var expires = DateTime.UtcNow.AddHours(24);

            var token = new JwtSecurityToken(
                issuer: "http://::80",
                audience: "http://::80",
                claims,
                notBefore: jwtDate,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
