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
    public class StudentsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public StudentsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> GetStudent()
        {
            return _context.Student;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _context.Student
                             .Where(s => s.StudentId == id)
                            .Include(s => s.Image)
                            .Include(s => s.Course)
                            .FirstAsync();

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent([FromRoute] string id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] Student student)
        {
            Console.WriteLine("======================================================");
            Console.WriteLine("Came to Student post");
            Console.WriteLine(student.StudentCourse);
            student.joinedYear = DateTime.Now.Year.ToString();
            var count = getCurrentYearStdCount(student.joinedYear) + 1;
            student.StudentId = student.StudentCourse + student.joinedYear+ count;

            var user = new User
            {
                UserName = student.StudentId,
                Password = student.StudentId,
                Role = "Student"   
            };
            student.Course = null;
            student.User = user;
            _context.Student.Add(student);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.StudentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }           

            /*   if (!ModelState.IsValid)
               {
                   return BadRequest(ModelState);
               }

               _context.Student.Add(student);
               try
               {
                   await _context.SaveChangesAsync();
               }
               catch (DbUpdateException)
               {
                   if (StudentExists(student.StudentId))
                   {
                       return new StatusCodeResult(StatusCodes.Status409Conflict);
                   }
                   else
                   {
                       throw;
                   }
               }*/

            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        private bool StudentExists(string id)
        {
            return _context.Student.Any(e => e.StudentId == id);
        }

        private int getCurrentYearStdCount(string year)
        {
            var count= _context.Student
                    .Where(s => s.joinedYear == year)
                    .Count();
            Console.WriteLine("COUNT IS :" + count);
            return count;
          
        }
    }
}