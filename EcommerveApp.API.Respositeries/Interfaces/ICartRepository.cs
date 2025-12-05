using ECommerce_Standard_.EcommerceApp.Core.Models;

namespace ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces
{
    public class ICartRepository
    {
        public Task<List<Product>> GetUserCart(int userId);
        public Task<bool> AddToCart(int userId, int itemId);
    }
}
