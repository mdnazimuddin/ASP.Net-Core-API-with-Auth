using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Models
{
    public class User
    {
      
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public string token { get; set; }

        public static explicit operator User(int v)
        {
            throw new NotImplementedException();
        }
    }
}
