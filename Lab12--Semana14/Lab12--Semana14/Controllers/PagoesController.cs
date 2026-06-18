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
    public class PagoesController : ControllerBase
    {
        private readonly DemoContext _context;

        public PagoesController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Pagoes
        [HttpGet]
        public IActionResult GetPagos()
        {
            var pagos = _context.Pagos
                .Where(p => !p.IsDeleted)
                .Select(p => new PagoResponse
                {
                    IdPago = p.IdPago,
                    IdMatricula = p.IdMatricula,
                    Monto = p.Monto,
                    FechaPago = p.FechaPago,
                    MetodoPago = p.MetodoPago,
                    EstadoPago = p.EstadoPago
                }).ToList();

            return Ok(pagos);
        }

        // GET: api/Pagoes/matricula/5
        [HttpGet("matricula/{idMatricula}")]
        public IActionResult GetPagosPorMatricula(int idMatricula)
        {
            var pagos = _context.Pagos
                .Where(p => p.IdMatricula == idMatricula && !p.IsDeleted)
                .Select(p => new PagoResponse
                {
                    IdPago = p.IdPago,
                    IdMatricula = p.IdMatricula,
                    Monto = p.Monto,
                    FechaPago = p.FechaPago,
                    MetodoPago = p.MetodoPago,
                    EstadoPago = p.EstadoPago
                }).ToList();

            return Ok(pagos);
        }

        // POST: api/Pagoes
        [HttpPost]
        public IActionResult PostPago(PagoRequest request)
        {
            try
            {
                var matricula = _context.Matriculas
                    .FirstOrDefault(m => m.IdMatricula == request.IdMatricula && !m.IsDeleted);

                if (matricula == null)
                {
                    return BadRequest(new { mensaje = "La matrícula no existe" });
                }

                if (request.Monto <= 0)
                {
                    return BadRequest(new { mensaje = "El monto debe ser mayor a 0" });
                }

                var pago = new Pago
                {
                    IdMatricula = request.IdMatricula,
                    Monto = request.Monto,
                    FechaPago = DateTime.Now,
                    MetodoPago = request.MetodoPago,
                    EstadoPago = "Completado",
                    IsDeleted = false
                };

                _context.Pagos.Add(pago);
                _context.SaveChanges();

                return Ok(new { mensaje = "Pago registrado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al registrar pago", error = ex.Message });
            }
        }

        // DELETE: api/Pagoes/5
        [HttpDelete("{id}")]
        public IActionResult DeletePago(int id)
        {
            var pago = _context.Pagos.FirstOrDefault(p => p.IdPago == id && !p.IsDeleted);

            if (pago == null)
            {
                return NotFound(new { mensaje = "Pago no encontrado" });
            }

            pago.IsDeleted = true;
            _context.SaveChanges();

            return Ok(new { mensaje = "Pago eliminado correctamente" });
        }
    }
}
