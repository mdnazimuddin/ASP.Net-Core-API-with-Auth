using Microsoft.AspNetCore.Http;
using Project_One.Gateway;
using Project_One.Interface;
using Project_One.Models;
using Project_One.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Repository
{
    public class UserRepository : IUserRepository

    {
        private readonly IHttpContextAccessor _accessor;
        public UserRepository(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public Task<List<User>> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public User GetUser()
        {
            var currentUser = _accessor.HttpContext.User.Claims.ToDictionary(c => c.Type, c => c.Value);
            User user = new User() { 
                Id = int.Parse(currentUser["Id"]),
                Name = currentUser["Name"],
                Email = currentUser["Email"],
            };
            return user;
        }

        public  string UserRegistation(RegisterUser user)
        {
            user.Password = MD5HashConverter.MD5Hash(user.Password);
            UserGateway.RegisterUser(user);
            return "User Registation Successfull";
        }

    }
}
