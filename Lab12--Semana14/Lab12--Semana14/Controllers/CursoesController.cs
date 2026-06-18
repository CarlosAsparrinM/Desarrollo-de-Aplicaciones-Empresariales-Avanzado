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
    public class CursoesController : ControllerBase
    {
        private readonly DemoContext _context;

        public CursoesController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Cursoes
        [HttpGet]
        public IActionResult GetCursos()
        {
            var cursos = (from c in _context.Cursos
                          join i in _context.Instructores on c.IdInstructor equals i.IdInstructor
                          where !c.IsDeleted
                          select new CursoResponse
                          {
                              IdCurso = c.IdCurso,
                              Nombre = c.Nombre,
                              Descripcion = c.Descripcion,
                              Precio = c.Precio,
                              DuracionHoras = c.DuracionHoras,
                              IdInstructor = c.IdInstructor,
                              NombreInstructor = i.Nombres + " " + i.Apellidos,
                              Activo = c.Activo
                          }).ToList();

            return Ok(cursos);
        }

        // GET: api/Cursoes/5
        [HttpGet("{id}")]
        public IActionResult GetCurso(int id)
        {
            var curso = (from c in _context.Cursos
                         join i in _context.Instructores on c.IdInstructor equals i.IdInstructor
                         where c.IdCurso == id && !c.IsDeleted
                         select new CursoResponse
                         {
                             IdCurso = c.IdCurso,
                             Nombre = c.Nombre,
                             Descripcion = c.Descripcion,
                             Precio = c.Precio,
                             DuracionHoras = c.DuracionHoras,
                             IdInstructor = c.IdInstructor,
                             NombreInstructor = i.Nombres + " " + i.Apellidos,
                             Activo = c.Activo
                         }).FirstOrDefault();

            if (curso == null)
            {
                return NotFound(new { mensaje = "Curso no encontrado" });
            }

            return Ok(curso);
        }

        // POST: api/Cursoes
        [HttpPost]
        public IActionResult PostCurso(CursoRequest request)
        {
            try
            {
                var instructor = _context.Instructores
                    .FirstOrDefault(i => i.IdInstructor == request.IdInstructor && !i.IsDeleted);

                if (instructor == null)
                {
                    return BadRequest(new { mensaje = "El instructor no existe" });
                }

                var curso = new Curso
                {
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion,
                    Precio = request.Precio,
                    DuracionHoras = request.DuracionHoras,
                    IdInstructor = request.IdInstructor,
                    Activo = true,
                    IsDeleted = false
                };

                _context.Cursos.Add(curso);
                _context.SaveChanges();

                return Ok(new { mensaje = "Curso registrado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al registrar curso", error = ex.Message });
            }
        }

        // PUT: api/Cursoes/5
        [HttpPut("{id}")]
        public IActionResult PutCurso(int id, CursoRequest request)
        {
            var curso = _context.Cursos.FirstOrDefault(c => c.IdCurso == id && !c.IsDeleted);

            if (curso == null)
            {
                return NotFound(new { mensaje = "Curso no encontrado" });
            }

            var instructor = _context.Instructores
                .FirstOrDefault(i => i.IdInstructor == request.IdInstructor && !i.IsDeleted);

            if (instructor == null)
            {
                return BadRequest(new { mensaje = "El instructor no existe" });
            }

            curso.Nombre = request.Nombre;
            curso.Descripcion = request.Descripcion;
            curso.Precio = request.Precio;
            curso.DuracionHoras = request.DuracionHoras;
            curso.IdInstructor = request.IdInstructor;

            _context.SaveChanges();

            return Ok(new { mensaje = "Curso actualizado correctamente" });
        }

        // DELETE: api/Cursoes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCurso(int id)
        {
            var curso = _context.Cursos.FirstOrDefault(c => c.IdCurso == id && !c.IsDeleted);

            if (curso == null)
            {
                return NotFound(new { mensaje = "Curso no encontrado" });
            }

            curso.IsDeleted = true;
            _context.SaveChanges();

            return Ok(new { mensaje = "Curso eliminado correctamente" });
        }
    }
}
