using Dapper;
using Project_One.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project_One.Gateway
{
    public class UserGateway : DbGateway
    {
        public static string LoadConnectionString()
        {
            return GetConnection();
        }

        public static int RegisterUser(RegisterUser user)
        {
            var query = "INSERT INTO [User] (Name, Email, Password) VALUES('" + user.Name + "', '" + user.Email + "', '" + user.Password + "')";
            using IDbConnection con = new SqlConnection(GetConnection());
            return con.Execute(query);
        }
        
    }
}
