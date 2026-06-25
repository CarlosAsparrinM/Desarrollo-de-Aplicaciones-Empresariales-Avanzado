using Microsoft.AspNetCore.Mvc;
using Lab13__Semana15.Models;
using Lab13__Semana15.Request;
using Lab13__Semana15.Response;

namespace Lab13__Semana15.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DemoContext _context;

        public ProductsController(DemoContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> GetProducts()
        {
            var products = _context.Products
                .Select(p => new ProductResponse
                {
                    IdProducts = p.IdProducts,
                    Name = p.Name,
                    Price = p.Price
                }).ToList();

            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public ActionResult<ProductResponse> GetProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            var response = new ProductResponse
            {
                IdProducts = product.IdProducts,
                Name = product.Name,
                Price = product.Price
            };

            return Ok(response);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, ProductRequest request)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = request.Name;
            product.Price = request.Price;

            _context.SaveChanges();

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public ActionResult<ProductResponse> PostProduct(ProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            var response = new ProductResponse
            {
                IdProducts = product.IdProducts,
                Name = product.Name,
                Price = product.Price
            };

            return CreatedAtAction("GetProduct", new { id = product.IdProducts }, response);
        }

        // DELETE: api/Products/5 (Eliminación lógica)
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            product.IsDeleted = true;
            _context.SaveChanges();

            return NoContent();
        }
    }
}
