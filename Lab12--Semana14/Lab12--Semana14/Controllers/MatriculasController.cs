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
    public class MatriculasController : ControllerBase
    {
        private readonly DemoContext _context;

        public MatriculasController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Matriculas
        [HttpGet]
        public IActionResult GetMatriculas()
        {
            var matriculas = (from m in _context.Matriculas
                              join e in _context.Estudiantes on m.IdEstudiante equals e.IdEstudiante
                              join c in _context.Cursos on m.IdCurso equals c.IdCurso
                              where !m.IsDeleted
                              select new MatriculaResponse
                              {
                                  IdMatricula = m.IdMatricula,
                                  IdEstudiante = m.IdEstudiante,
                                  NombreEstudiante = e.Nombres + " " + e.Apellidos,
                                  IdCurso = m.IdCurso,
                                  NombreCurso = c.Nombre,
                                  FechaMatricula = m.FechaMatricula,
                                  Estado = m.Estado,
                                  MontoTotal = m.MontoTotal
                              }).ToList();

            return Ok(matriculas);
        }

        // GET: api/Matriculas/5
        [HttpGet("{id}")]
        public IActionResult GetMatricula(int id)
        {
            var matricula = (from m in _context.Matriculas
                             join e in _context.Estudiantes on m.IdEstudiante equals e.IdEstudiante
                             join c in _context.Cursos on m.IdCurso equals c.IdCurso
                             where m.IdMatricula == id && !m.IsDeleted
                             select new MatriculaResponse
                             {
                                 IdMatricula = m.IdMatricula,
                                 IdEstudiante = m.IdEstudiante,
                                 NombreEstudiante = e.Nombres + " " + e.Apellidos,
                                 IdCurso = m.IdCurso,
                                 NombreCurso = c.Nombre,
                                 FechaMatricula = m.FechaMatricula,
                                 Estado = m.Estado,
                                 MontoTotal = m.MontoTotal
                             }).FirstOrDefault();

            if (matricula == null)
            {
                return NotFound(new { mensaje = "Matrícula no encontrada" });
            }

            return Ok(matricula);
        }

        // POST: api/Matriculas
        [HttpPost]
        public IActionResult PostMatricula(MatriculaRequest request)
        {
            try
            {
                var estudiante = _context.Estudiantes
                    .FirstOrDefault(e => e.IdEstudiante == request.IdEstudiante && !e.IsDeleted);

                if (estudiante == null)
                {
                    return BadRequest(new { mensaje = "El estudiante no existe" });
                }

                var curso = _context.Cursos
                    .FirstOrDefault(c => c.IdCurso == request.IdCurso && !c.IsDeleted);

                if (curso == null)
                {
                    return BadRequest(new { mensaje = "El curso no existe" });
                }

                var matricula = new Matricula
                {
                    IdEstudiante = request.IdEstudiante,
                    IdCurso = request.IdCurso,
                    FechaMatricula = DateTime.Now,
                    Estado = "Activa",
                    MontoTotal = curso.Precio,
                    IsDeleted = false
                };

                _context.Matriculas.Add(matricula);
                _context.SaveChanges();

                return Ok(new { mensaje = "Matrícula registrada correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al registrar matrícula", error = ex.Message });
            }
        }

        // DELETE: api/Matriculas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMatricula(int id)
        {
            var matricula = _context.Matriculas.FirstOrDefault(m => m.IdMatricula == id && !m.IsDeleted);

            if (matricula == null)
            {
                return NotFound(new { mensaje = "Matrícula no encontrada" });
            }

            matricula.IsDeleted = true;
            _context.SaveChanges();

            return Ok(new { mensaje = "Matrícula eliminada correctamente" });
        }
    }
}
