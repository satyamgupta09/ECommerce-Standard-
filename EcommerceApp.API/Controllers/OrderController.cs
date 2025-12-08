using ECommerce_Standard_.EcommerceApp.Core.Models;
using ECommerce_Standard_.EcommerceAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Standard_.EcommerceApp.API.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderServie)
        {
            _orderService = orderServie;
        }

        [HttpGet("AddUserOrder")]

        public async Task<IActionResult> AddUserOrder(int userId, List<Product> products)
        {
            var isAdded = await _orderService.AddUserOrder(userId, products);
            if (!isAdded)
            {
                return BadRequest("Not able to add");
            }
            return Ok("item added successfully");
        }

        [HttpPost("getUserOrders")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            var orders = await _orderService.GetUserOrders(userId);
            if(orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }
    }
}
