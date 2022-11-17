using Project_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Interface
{
    public  interface ILoginRepository
    {
        public User Login(LoginUser user);
    }
}
