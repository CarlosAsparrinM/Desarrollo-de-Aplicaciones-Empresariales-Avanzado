using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12__Semana14.Models;
using Lab12__Semana14.Response;

namespace Lab12__Semana14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DemoContext _context;

        public DashboardController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Dashboard/resumen
        [HttpGet("resumen")]
        public IActionResult Resumen()
        {
            var resumen = new DashboardResponse
            {
                TotalEstudiantes = _context.Estudiantes.Count(e => !e.IsDeleted),
                TotalInstructores = _context.Instructores.Count(i => !i.IsDeleted),
                TotalCursos = _context.Cursos.Count(c => !c.IsDeleted),
                TotalMatriculas = _context.Matriculas.Count(m => !m.IsDeleted),
                TotalPagos = _context.Pagos.Count(p => !p.IsDeleted),
                MontoTotalPagado = _context.Pagos.Where(p => !p.IsDeleted).Sum(p => p.Monto)
            };

            return Ok(resumen);
        }
    }
}
