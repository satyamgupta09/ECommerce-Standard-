using ECommerce_Standard_.EcommerceAppAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Standard_.EcommerceApp.API.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("getUserCart")]
        public async Task<IActionResult> GetUserCart(int userId)
        {
            var cart = await _cartService.GetUserCart(userId);
            if(cart == null)
            {
                return NotFound("Cart not found for the user");
            }
            return Ok(cart);
        }

        [HttpPost("addToCart")]
        public async Task<IActionResult> AddToCart(int userId, int itemId)
        {
            var isAdded = await _cartService.AddToCart(userId, itemId);
            if (!isAdded)
            {
                return BadRequest("Failed to add item to cart");
            }
            return Ok("Item added to cart successfully");
        }
    }
}
