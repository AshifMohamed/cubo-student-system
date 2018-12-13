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
    [Route("api/lecturers")]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly ILecturerDBService lecturerService;

        public LecturersController(ILecturerDBService lecturerService)
        {
            this.lecturerService = lecturerService;
        }

        [HttpGet]
        public async Task<IEnumerable<Lecturer>> GetLecturer()
        {
            return await lecturerService.GetAllLecturers();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLecturer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lecturer = await lecturerService.GetLecturer(id);

            if (lecturer == null)
            {
                return NotFound();
            }

            return Ok(lecturer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLecturer([FromRoute] int id, [FromBody] Lecturer lecturer)
        {
            if (id != lecturer.LecturerId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await lecturerService.CheckLecturerExists(lecturer.LecturerId))
            {
                return NotFound();
            }
            lecturerService.UpdateLecturer(id, lecturer);
            await lecturerService.SaveLecturer();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostLecturer([FromBody] Lecturer lecturer)
        {
            if (await lecturerService.CheckLecturerExists(lecturer.LecturerId))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            lecturerService.CreateLecturer(lecturer);
            await lecturerService.SaveLecturer();

            return CreatedAtAction("GetLecturer", new { id = lecturer.LecturerId }, lecturer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturer([FromRoute] string id)
        {
            var lecturer = await lecturerService.GetLecturer(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            lecturerService.DeleteLecturer(lecturer);
            await lecturerService.SaveLecturer();

            return Ok(lecturer);
        }

    }
}