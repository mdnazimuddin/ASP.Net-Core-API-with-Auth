using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Gateway
{
    public class DbGateway
    {
        public static readonly string Type = "dev";
        public static readonly string ProdConnectionString = @"Data Source=HUMAN-LAPTOP\SQLEXPRESS; Initial Catalog=UserWebApi;  Persist Security Info=True; User ID=sa; Password=12345678";
        public static readonly string DevConnectionString = @"Data Source=HUMAN-LAPTOP\SQLEXPRESS; Initial Catalog=UserWebApi; Trusted_Connection=true";

        public static string GetConnection()
        {
            return Type == "pro" ? ProdConnectionString : DevConnectionString;
        }
    }
}
