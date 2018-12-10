using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;
using ServerApp.Services;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserDBService userService;

        public LoginController(IUserDBService userService)
        {
            this.userService = userService;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {          

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userService.CheckUserExists(user))
            {
                return Ok(userService.GetUser(user.UserName));
            }
            
            else
            {
                return Ok(new User());
            }
            
        }
       
    }
}