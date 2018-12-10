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
    public class UsersController : ControllerBase
    {
        private readonly  IUserDBService userService;

        public UsersController(IUserDBService userService)
        {
            this.userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return userService.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user =  userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] string id, [FromBody] User user)
        {
            if (id != user.UserName)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!userService.CheckUserExists(user))
            {
                return NotFound();
            }
            userService.UpdateUser(id, user);
            userService.SaveUser();

            return Ok();

        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (userService.CheckUsernameExists(user.UserName))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userService.CreateUser(user);
            userService.SaveUser();

            return CreatedAtAction("GetUser", new { id = user.UserName }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var user = userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            userService.DeleteUser(user);
            userService.SaveUser();

            return Ok(user);
        }
      
    }
}