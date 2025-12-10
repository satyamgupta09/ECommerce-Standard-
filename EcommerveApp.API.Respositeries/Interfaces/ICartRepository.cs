using ECommerce_Standard_.EcommerceApp.Core.DTOs.response;
using ECommerce_Standard_.EcommerceApp.Core.Models;

namespace ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces
{
    public interface ICartRepository
    {
        public Task<List<GetUserCartResponse>> GetUserCart(int userId);
        public Task<bool> AddToCart(int userId, int itemId);
        public Task<bool> IncreaseQty(int userId, int productId);
        public Task<bool> DecreaseQty(int userId, int productId);
    }
}
