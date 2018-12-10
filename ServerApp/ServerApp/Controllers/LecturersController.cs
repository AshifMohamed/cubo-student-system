﻿using System;
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
    public class LecturersController : ControllerBase
    {
        private readonly ILecturerDBService lecturerService;

        public LecturersController(ILecturerDBService lecturerService)
        {
            this.lecturerService = lecturerService;
        }

        // GET: api/Lecturers
        [HttpGet]
        public IEnumerable<Lecturer> GetLecturer()
        {
            return lecturerService.GetAllLecturers();
        }

        // GET: api/Lecturers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLecturer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lecturer = lecturerService.GetLecturer(id);

            if (lecturer == null)
            {
                return NotFound();
            }

            return Ok(lecturer);
        }

        // PUT: api/Lecturers/5
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

            if (!lecturerService.CheckLecturerExists(lecturer.LecturerId))
            {
                return NotFound();
            }
            lecturerService.UpdateLecturer(id, lecturer);
            lecturerService.SaveLecturer();

            return Ok();
        }

        // POST: api/Lecturers
        [HttpPost]
        public async Task<IActionResult> PostLecturer([FromBody] Lecturer lecturer)
        {
            if (lecturerService.CheckLecturerExists(lecturer.LecturerId))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            lecturerService.CreateLecturer(lecturer);
            lecturerService.SaveLecturer();

            return CreatedAtAction("GetLecturer", new { id = lecturer.LecturerId }, lecturer);
        }

        // DELETE: api/Lecturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLecturer([FromRoute] string id)
        {
            var lecturer = lecturerService.GetLecturer(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            lecturerService.DeleteLecturer(lecturer);
            lecturerService.SaveLecturer();

            return Ok(lecturer);
        }

    }
}