using ECommerce_Standard_.EcommerceApp.Core.Models;

namespace ECommerce_Standard_.EcommerceAppAPI.Services.Interfaces
{
    public interface ICartService
    {
        public Task<List<Product>> GetUserCart(int userId);
        public Task<bool> AddToCart(int userId, int itemId);

        public Task<bool> IncreaseQty(int userId, int productId);
        public Task<bool> DecreaseQty(int userId, int productId);
    }
}
