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
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseDBService courseService;

        public CoursesController(ICourseDBService courseService)
        {
            this.courseService = courseService;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<IEnumerable<Course>> GetCourse()
        {           
            return await courseService.GetAllCourses();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await courseService.GetCourse(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse([FromRoute] string id, [FromBody] Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await courseService.CheckCourseExists(course.CourseId))
            {
                return NotFound();
            }
            courseService.UpdateCourse(id, course);
            await courseService.SaveCourse();

            return Ok();
        }

        // POST: api/Courses
        [HttpPost]
        public async Task<IActionResult> PostCourse([FromBody] Course course)
        {
            if (await courseService.CheckCourseExists(course.CourseId) ||
                await courseService.CheckCourseNameExists(course.CourseName))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
       
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            courseService.CreateCourse(course);
            await courseService.SaveCourse();

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] string id)
        {
            var course = await courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }

            courseService.DeleteCourse(course);
            await courseService.SaveCourse();

            return Ok(course);
        }
      
    }
}