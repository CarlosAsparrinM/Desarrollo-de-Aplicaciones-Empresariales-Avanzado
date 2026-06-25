using Microsoft.AspNetCore.Mvc;
using Lab13__Semana15.Models;
using Lab13__Semana15.Response;

namespace Lab13__Semana15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly DemoContext _context;

        public InvoicesController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Invoices/ByCustomerName?nombre=x
        [HttpGet("ByCustomerName")]
        public ActionResult<IEnumerable<InvoiceByCustomerResponse>> GetInvoicesByCustomerName(string nombre)
        {
            var result = (from i in _context.Invoices
                          join c in _context.Customers on i.Customers_idCustomers equals c.IdCustomers
                          where c.FirstName.Contains(nombre)
                          orderby c.FirstName descending
                          select new InvoiceByCustomerResponse
                          {
                              IdInvoices = i.IdInvoices,
                              InvoiceNumber = i.InvoiceNumber,
                              Date = i.Date,
                              Total = i.Total,
                              CustomerFirstName = c.FirstName,
                              CustomerLastName = c.LastName,
                              CustomerDocumentNumber = c.DocumentNumber
                          }).ToList();

            return Ok(result);
        }
    }
}
