using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Project_One.Utility
{
    public class JwtAuth<T>  
    {
        private readonly IConfiguration _config;
        public static readonly string ConnectionString = @"Data Source=HUMAN-LAPTOP\SQLEXPRESS; Initial Catalog=UserWebApi; Trusted_Connection=true";
        public JwtAuth(IConfiguration configaration)
        {
            _config = configaration;
        }
        public dynamic Attempt(dynamic model, string username = "Email", string password = "Password", bool md5 = true)
        {

            var _table = (model.GetType().GetProperty("Table") != null) ? model.Table : (model.GetType().GetProperty("table") != null) ? model.table : model.GetType().Name;

            var json = JsonConvert.SerializeObject(model);
            string _username = JObject.Parse(json)[username].ToString();
            string _password = JObject.Parse(json)[password].ToString();
            _password = md5 ? MD5Hash(_password) : _password;

            var query = "SELECT * FROM [" + _table + "] WHERE " + username + " = '" + _username + "' AND " + password + " = '" + _password + "'";
            
            dynamic data = GetQueryFirst<T>(query);

            if (data != null)
            {
                data.token = GenerateJWTToken(data,username: _username);
            }
            return data;
        }
        private string GenerateJWTToken(dynamic userInfo,string username)
        {
            var data = JsonConvert.DeserializeObject<IDictionary>(JsonConvert.SerializeObject(userInfo));
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, username));
            foreach (var item in data)
            {
                var key = item.Key;
                var value = item.Value;
                if(value != null)
                {
                    claims.Add(new Claim(key, value.ToString()));
                }
            }
            
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_config["Jwt:Expires"])),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static string MD5Hash(string input)
        {
            using MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public  dynamic GetQueryFirst<T>(string query)
        {
            using IDbConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            dynamic data = con.Query<T>(query).FirstOrDefault();
            return data;
        }

    }
}
