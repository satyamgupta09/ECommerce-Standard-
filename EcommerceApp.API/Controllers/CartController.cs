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

        [HttpPost("increaseQty")]

        public async Task<IActionResult> IncreaseQty(int userId, int itemId)
        {
            var isIncreased = await _cartService.IncreaseQty(userId, itemId);
            if (!isIncreased)
            {
                return BadRequest("Not able to increased");
            }
            return Ok("increased");
        }

        [HttpPost("decreaseQty")]
        public async Task<IActionResult> DecreaseQty(int userId, int itemId)
        {
            var isDecreased = await _cartService.DecreaseQty(userId,itemId);
            if (!isDecreased)
            {
                return BadRequest("Not able to decreased");
            }
            return Ok("decreased");
        }
    }
}
