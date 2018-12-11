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
using ServerApp.Services;

namespace ServerApp.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentDBService studentService;

        public StudentsController(IStudentDBService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudent()
        {
            return await studentService.GetAllStudents();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await studentService.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent([FromRoute] string id, [FromBody] Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }          

            if (!await studentService.CheckStudentExists(student.StudentId))
            {
                return NotFound();
            }
            studentService.UpdateStudent(id, student);
            await studentService.SaveStudent();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] Student student)
        {
            if (await studentService.CheckStudentExists(student.StudentId))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await studentService.CreateStudent(student);
            await studentService.SaveStudent();

            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] string id)
        {

            var student = await studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            studentService.DeleteStudent(student);
            await studentService.SaveStudent();

            return Ok(student);
        }

    }
}