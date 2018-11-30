using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public LoginController(DatabaseContext context)
        {
            _context = context;
        }
     
        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            Console.WriteLine("Server Came");
            Console.WriteLine(user.UserName+" "+user.Password);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (UserExists(user.UserName, user.Password))
            {
                return Ok(await _context.User.FindAsync(user.UserName));
            }

            else
            {
                return Ok(new User());
            }
            
        }

        private bool UserExists(string id, string pwd)
        {
            return _context.User.Any(e => e.UserName == id && e.Password == pwd);
        }

        // GET: api/Login/5
      /*  [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }*/

    }
}