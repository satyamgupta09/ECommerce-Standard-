using ECommerce_Standard_.EcommerceAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Standard_.EcommerceApp.API.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet("products")]
        public IActionResult GetAllProducts()
        {
            var products = _service.GetAllProducts();
            if(products == null)
            {
                return NotFound("No products found");
            }
            return Ok(products);
        }

        [HttpGet("products/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _service.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }
}
