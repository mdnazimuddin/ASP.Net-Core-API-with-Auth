using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_One.Interface;
using Project_One.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_One.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoginRepository _loginRepository;
        public UserController(IUserRepository userRepository,ILoginRepository loginRepository)
        {
            _userRepository = userRepository;
            _loginRepository = loginRepository;
        }

        [HttpPost("register")]
        public  IActionResult Register([FromBody]RegisterUser user)
        {
            var result =  _userRepository.UserRegistation(user);
            return Ok(result);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginUser user)
        {
            User _user =  _loginRepository.Login(user);
            if(_user != null)
            {
                return Ok(_user);
            }

            return Unauthorized();
        }
        [HttpGet()]
        [Route("GetData")]
        [Authorize]
        public IActionResult GetUser()
        {
            var user = _userRepository.GetUser();
            return Ok(user);
        }

    }
}
