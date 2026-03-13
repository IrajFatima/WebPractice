using homework2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace homework2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>();
        private static int id = 1;
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
            {
                ModelState.AddModelError(nameof(product.Name), nameof(product.Name) + " cannot be null or empty");
            }
            if(product.Price <= 0)
            {
                ModelState.AddModelError(nameof(product.Price), nameof(product.Price) + " cannot be negative or zero");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            product.Id = id++;
            products.Add(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
