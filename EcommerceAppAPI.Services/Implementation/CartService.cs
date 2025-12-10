using ECommerce_Standard_.EcommerceApp.Core.DTOs.response;
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

        public Task<List<GetUserCartResponse>> GetUserCart(int userId)
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

        public async Task<bool> IncreaseQty(int userId, int productId)
        {
            var isIncreased = await _cartRepository.IncreaseQty(userId, productId);
            if (!isIncreased)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DecreaseQty(int userId, int productId)
        {
            var isDecreased = await _cartRepository.DecreaseQty(userId, productId);
            if(!isDecreased)
            {
                return false;
            }
            return true;
        }
    }
}
