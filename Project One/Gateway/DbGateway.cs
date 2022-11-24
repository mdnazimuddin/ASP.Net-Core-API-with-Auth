using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

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

        public static dynamic GetQueryFirst<T>( string query)
        {
            using IDbConnection con = new SqlConnection(GetConnection());
            dynamic data = con.Query<T>(query).FirstOrDefault();
            return data;
        }
        public static dynamic GetQueryList<T>(string query)
        {
            using IDbConnection con = new SqlConnection(GetConnection());
            dynamic data = con.Query<T>(query).ToList();
            return data;
        }
        public static dynamic GetExecute(string query)
        {
            using IDbConnection con = new SqlConnection(GetConnection());
            dynamic data = con.Execute(query);
            return data;
        }
    }
}
