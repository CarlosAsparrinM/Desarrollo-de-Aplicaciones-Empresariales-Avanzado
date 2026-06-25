using Microsoft.AspNetCore.Mvc;
using Lab13__Semana15.Models;
using Lab13__Semana15.Request;
using Lab13__Semana15.Response;

namespace Lab13__Semana15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly DemoContext _context;

        public DetailsController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Details/ByInvoiceNumber?invoiceNumber=x
        [HttpGet("ByInvoiceNumber")]
        public ActionResult<IEnumerable<DetailByInvoiceNumberResponse>> GetDetailsByInvoiceNumber(string invoiceNumber)
        {
            var result = (from d in _context.Details
                          join i in _context.Invoices on d.Invoices_idInvoices equals i.IdInvoices
                          join c in _context.Customers on i.Customers_idCustomers equals c.IdCustomers
                          where i.InvoiceNumber.Contains(invoiceNumber)
                          orderby c.FirstName, i.InvoiceNumber
                          select new DetailByInvoiceNumberResponse
                          {
                              IdDetails = d.IdDetails,
                              Amount = d.Amount,
                              Price = d.Price,
                              SubTotal = d.SubTotal,
                              InvoiceNumber = i.InvoiceNumber,
                              InvoiceDate = i.Date,
                              InvoiceTotal = i.Total,
                              CustomerFirstName = c.FirstName,
                              CustomerLastName = c.LastName
                          }).ToList();

            return Ok(result);
        }

        // GET: api/Details/ByDateRange?fechaInicio=2024-01-01&fechaFin=2024-12-31
        [HttpGet("ByDateRange")]
        public ActionResult<IEnumerable<DetailByDateResponse>> GetDetailsByDateRange([FromQuery] DetailByDateRequest request)
        {
            var result = (from d in _context.Details
                          join i in _context.Invoices on d.Invoices_idInvoices equals i.IdInvoices
                          join p in _context.Products on d.Products_idProducts equals p.IdProducts
                          where i.Date >= request.FechaInicio && i.Date <= request.FechaFin
                          orderby i.Date, p.Name
                          select new DetailByDateResponse
                          {
                              IdDetails = d.IdDetails,
                              Amount = d.Amount,
                              DetailPrice = d.Price,
                              SubTotal = d.SubTotal,
                              InvoiceNumber = i.InvoiceNumber,
                              InvoiceDate = i.Date,
                              InvoiceTotal = i.Total,
                              ProductName = p.Name,
                              ProductPrice = p.Price
                          }).ToList();

            return Ok(result);
        }
    }
}
