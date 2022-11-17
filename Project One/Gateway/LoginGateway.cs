using Dapper;
using Project_One.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Gateway
{
    public class LoginGateway : DbGateway
    {
        public static User Login(LoginUser user)
        {
            var query = "SELECT * FROM [User] WHERE Email = '"+user.Email+ "' AND Password = '" + user.Password + "'";
            using IDbConnection con = new SqlConnection(GetConnection());
            return  con.Query<User>(query).FirstOrDefault();
        }

    }
}
