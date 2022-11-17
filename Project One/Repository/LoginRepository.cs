using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_One.Gateway;
using Project_One.Interface;
using Project_One.Models;
using Project_One.Utility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project_One.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConfiguration _config;
        public LoginRepository(IConfiguration configaration)
        {
            _config = configaration;
        }

        public User Login(LoginUser user)
        {
            user.Password = MD5HashConverter.MD5Hash(user.Password);
            User _user =  LoginGateway.Login(user);
            if(_user != null)
            {
                _user.token = GenerateJWTToken(_user);
            }
            return _user;
        }

        private string GenerateJWTToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                new Claim("Id", userInfo.Id.ToString()),
                new Claim("Name", userInfo.Name),
                new Claim("Email",userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
