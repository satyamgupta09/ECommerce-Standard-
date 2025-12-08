using ECommerce_Standard_.EcommerceApp.Core.DTOs.response;
using ECommerce_Standard_.EcommerceApp.Core.Models;

namespace ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces
{
    public interface IOrderRepository
    {
        public Task<bool> AddUserOrder(int userId, List<Product> products);
        public Task<List<OrderResponse>> GetUserOrders(int userId);
    }
}
