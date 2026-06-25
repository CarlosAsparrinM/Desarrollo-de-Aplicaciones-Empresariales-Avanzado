using Microsoft.AspNetCore.Mvc;
using Lab13__Semana15.Models;
using Lab13__Semana15.Request;
using Lab13__Semana15.Response;

namespace Lab13__Semana15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DemoContext _context;

        public CustomersController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomerResponse>> GetCustomers()
        {
            var customers = _context.Customers
                .Select(c => new CustomerResponse
                {
                    IdCustomers = c.IdCustomers,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DocumentNumber = c.DocumentNumber
                }).ToList();

            return Ok(customers);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public ActionResult<CustomerResponse> GetCustomer(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            var response = new CustomerResponse
            {
                IdCustomers = customer.IdCustomers,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DocumentNumber = customer.DocumentNumber
            };

            return Ok(response);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public IActionResult PutCustomer(int id, CustomerRequest request)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.DocumentNumber = request.DocumentNumber;

            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public ActionResult<CustomerResponse> PostCustomer(CustomerRequest request)
        {
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DocumentNumber = request.DocumentNumber
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();

            var response = new CustomerResponse
            {
                IdCustomers = customer.IdCustomers,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DocumentNumber = customer.DocumentNumber
            };

            return CreatedAtAction("GetCustomer", new { id = customer.IdCustomers }, response);
        }

        // DELETE: api/Customers/5 (Eliminación lógica)
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return NotFound();
            }

            customer.IsDeleted = true;
            _context.SaveChanges();

            return NoContent();
        }

        // GET: api/Customers/Search?nombre=x&apellido=y&documento=z
        [HttpGet("Search")]
        public ActionResult<IEnumerable<CustomerSearchResponse>> SearchCustomers(string? nombre, string? apellido, string? documento)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(c => c.FirstName.Contains(nombre));
            }

            if (!string.IsNullOrEmpty(apellido))
            {
                query = query.Where(c => c.LastName.Contains(apellido));
            }

            if (!string.IsNullOrEmpty(documento))
            {
                query = query.Where(c => c.DocumentNumber.Contains(documento));
            }

            var result = query
                .OrderByDescending(c => c.LastName)
                .Select(c => new CustomerSearchResponse
                {
                    IdCustomers = c.IdCustomers,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    DocumentNumber = c.DocumentNumber
                }).ToList();

            return Ok(result);
        }
    }
}
