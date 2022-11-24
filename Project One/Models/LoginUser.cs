using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Models
{
    public class LoginUser
    {

        public string Table { get; set; } = "User"; 
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
