using ECommerce_Standard_.EcommerceApp.Core.DTOs.response;
using ECommerce_Standard_.EcommerceApp.Core.Models;

namespace ECommerce_Standard_.EcommerceAppAPI.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> AddUserOrder(int userId, List<Product> products);
        public Task<List<OrderResponse>> GetUserOrders(int userId);
    }
}
