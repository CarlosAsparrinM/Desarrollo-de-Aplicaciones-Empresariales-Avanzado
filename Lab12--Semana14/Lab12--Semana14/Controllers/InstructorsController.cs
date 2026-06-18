using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12__Semana14.Models;
using Lab12__Semana14.Request;
using Lab12__Semana14.Response;

namespace Lab12__Semana14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly DemoContext _context;

        public InstructorsController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Instructors
        [HttpGet]
        public IActionResult GetInstructores()
        {
            var instructores = _context.Instructores
                .Where(i => !i.IsDeleted)
                .Select(i => new InstructorResponse
                {
                    IdInstructor = i.IdInstructor,
                    Nombres = i.Nombres,
                    Apellidos = i.Apellidos,
                    Especialidad = i.Especialidad,
                    Email = i.Email,
                    Activo = i.Activo
                }).ToList();

            return Ok(instructores);
        }

        // GET: api/Instructors/5
        [HttpGet("{id}")]
        public IActionResult GetInstructor(int id)
        {
            var instructor = _context.Instructores
                .Where(i => i.IdInstructor == id && !i.IsDeleted)
                .Select(i => new InstructorResponse
                {
                    IdInstructor = i.IdInstructor,
                    Nombres = i.Nombres,
                    Apellidos = i.Apellidos,
                    Especialidad = i.Especialidad,
                    Email = i.Email,
                    Activo = i.Activo
                }).FirstOrDefault();

            if (instructor == null)
            {
                return NotFound(new { mensaje = "Instructor no encontrado" });
            }

            return Ok(instructor);
        }

        // POST: api/Instructors
        [HttpPost]
        public IActionResult PostInstructor(InstructorRequest request)
        {
            try
            {
                var instructor = new Instructor
                {
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    Especialidad = request.Especialidad,
                    Email = request.Email,
                    Activo = true,
                    IsDeleted = false
                };

                _context.Instructores.Add(instructor);
                _context.SaveChanges();

                return Ok(new { mensaje = "Instructor registrado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al registrar instructor", error = ex.Message });
            }
        }

        // PUT: api/Instructors/5
        [HttpPut("{id}")]
        public IActionResult PutInstructor(int id, InstructorRequest request)
        {
            var instructor = _context.Instructores.FirstOrDefault(i => i.IdInstructor == id && !i.IsDeleted);

            if (instructor == null)
            {
                return NotFound(new { mensaje = "Instructor no encontrado" });
            }

            instructor.Nombres = request.Nombres;
            instructor.Apellidos = request.Apellidos;
            instructor.Especialidad = request.Especialidad;
            instructor.Email = request.Email;

            _context.SaveChanges();

            return Ok(new { mensaje = "Instructor actualizado correctamente" });
        }

        // DELETE: api/Instructors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInstructor(int id)
        {
            var instructor = _context.Instructores.FirstOrDefault(i => i.IdInstructor == id && !i.IsDeleted);

            if (instructor == null)
            {
                return NotFound(new { mensaje = "Instructor no encontrado" });
            }

            instructor.IsDeleted = true;
            _context.SaveChanges();

            return Ok(new { mensaje = "Instructor eliminado correctamente" });
        }
    }
}
