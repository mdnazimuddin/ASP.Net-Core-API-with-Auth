using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Models
{
    public class LoginUser
    {
      
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
