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
    public class EstudiantesController : ControllerBase
    {
        private readonly DemoContext _context;

        public EstudiantesController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Estudiantes
        [HttpGet]
        public IActionResult GetEstudiantes()
        {
            var estudiantes = _context.Estudiantes
                .Where(e => !e.IsDeleted)
                .Select(e => new EstudianteResponse
                {
                    IdEstudiante = e.IdEstudiante,
                    Nombres = e.Nombres,
                    Apellidos = e.Apellidos,
                    Email = e.Email,
                    Telefono = e.Telefono,
                    FechaRegistro = e.FechaRegistro,
                    Activo = e.Activo
                }).ToList();

            return Ok(estudiantes);
        }

        // GET: api/Estudiantes/5
        [HttpGet("{id}")]
        public IActionResult GetEstudiante(int id)
        {
            var estudiante = _context.Estudiantes
                .Where(e => e.IdEstudiante == id && !e.IsDeleted)
                .Select(e => new EstudianteResponse
                {
                    IdEstudiante = e.IdEstudiante,
                    Nombres = e.Nombres,
                    Apellidos = e.Apellidos,
                    Email = e.Email,
                    Telefono = e.Telefono,
                    FechaRegistro = e.FechaRegistro,
                    Activo = e.Activo
                }).FirstOrDefault();

            if (estudiante == null)
            {
                return NotFound(new { mensaje = "Estudiante no encontrado" });
            }

            return Ok(estudiante);
        }

        // POST: api/Estudiantes
        [HttpPost]
        public IActionResult PostEstudiante(EstudianteRequest request)
        {
            try
            {
                var estudiante = new Estudiante
                {
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    Email = request.Email,
                    Telefono = request.Telefono,
                    FechaRegistro = DateTime.Now,
                    Activo = true,
                    IsDeleted = false
                };

                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges();

                return Ok(new { mensaje = "Estudiante registrado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al registrar estudiante", error = ex.Message });
            }
        }

        // PUT: api/Estudiantes/5
        [HttpPut("{id}")]
        public IActionResult PutEstudiante(int id, EstudianteRequest request)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.IdEstudiante == id && !e.IsDeleted);

            if (estudiante == null)
            {
                return NotFound(new { mensaje = "Estudiante no encontrado" });
            }

            estudiante.Nombres = request.Nombres;
            estudiante.Apellidos = request.Apellidos;
            estudiante.Email = request.Email;
            estudiante.Telefono = request.Telefono;

            _context.SaveChanges();

            return Ok(new { mensaje = "Estudiante actualizado correctamente" });
        }

        // DELETE: api/Estudiantes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEstudiante(int id)
        {
            var estudiante = _context.Estudiantes.FirstOrDefault(e => e.IdEstudiante == id && !e.IsDeleted);

            if (estudiante == null)
            {
                return NotFound(new { mensaje = "Estudiante no encontrado" });
            }

            estudiante.IsDeleted = true;
            _context.SaveChanges();

            return Ok(new { mensaje = "Estudiante eliminado correctamente" });
        }
    }
}
