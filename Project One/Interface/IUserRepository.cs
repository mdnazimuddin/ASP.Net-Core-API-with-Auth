using Project_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Interface
{
    public interface IUserRepository
    {
       public string UserRegistation(RegisterUser user);
        public Task<List<User>> GetAllUser();
        public User GetUser();
    }
}
