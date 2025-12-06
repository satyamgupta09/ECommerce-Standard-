using ECommerce_Standard_.EcommerceApp.Core.Models;
using ECommerce_Standard_.EcommerceAppAPI.Services.Interfaces;
using ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ECommerce_Standard_.EcommerceAppAPI.Services.Implementation
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Task<List<Product>> GetUserCart(int userId)
        {
            var cart = _cartRepository.GetUserCart(userId);
            if(cart == null)
            {
                return null;
            }
            return cart;
        }

        public async Task<bool> AddToCart(int userId, int itemId)
        {
            var isAdded = await _cartRepository.AddToCart(userId, itemId);

            if (!isAdded)
            {
                return false;
            }
            return true;
        }
    }
}
