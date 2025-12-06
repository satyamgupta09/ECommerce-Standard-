using ECommerce_Standard_.EcommerceApp.Core.Models;

namespace ECommerce_Standard_.EcommerceAppAPI.Services.Interfaces
{
    public class ICartService
    {
        public Task<List<Cart>> GetUserCart(int userId);
        public Task<Cart> AddToCart(int userId, int itemId);
    }
}
