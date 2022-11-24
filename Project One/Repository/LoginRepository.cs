using Microsoft.Extensions.Configuration;
using Project_One.Interface;
using Project_One.Models;
using Project_One.Utility;

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

            User _user = new JwtAuth<User>(_config).Attempt(model:user);
            return _user;
        }

    }
}
