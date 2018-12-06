using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerApp.Helpers;
using ServerApp.Interfaces;
using ServerApp.Models;
using ServerApp.Constants;


namespace ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public StudentsController(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapper = repositoryWrapper;
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<Student> GetStudent()
        {
            return _repoWrapper.Student.FindAll();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _repoWrapper.Student.FindStudent(id);

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

            _repoWrapper.Student.Update(student);

            try
            {
                _repoWrapper.Student.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repoWrapper.Student.StudentExists(id))
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
            student.joinedYear = DateHelper.GetCurrentyear();
            var count = _repoWrapper.Student.GetCurrentYearStdCount() + 1;
            student.StudentId = student.StudentCourse + student.joinedYear+ count;

            var user = new User
            {
                UserName = student.StudentId,
                Password = student.StudentId,
                Role = Constant.studentRole   
            };
            student.Course = null;
            student.User = user;
            _repoWrapper.Student.Create(student);

            try
            {
                _repoWrapper.Student.Save();
            }
            catch (DbUpdateException)
            {
                if (_repoWrapper.Student.StudentExists(student.StudentId))
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

            var student =  _repoWrapper.Student.FindStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            _repoWrapper.Student.Delete(student);
            _repoWrapper.Student.Save();

            return Ok(student);
        }

    }
}