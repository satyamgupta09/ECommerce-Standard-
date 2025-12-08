using ECommerce_Standard_.EcommerceApp.Core.DTOs.response;
using ECommerce_Standard_.EcommerceApp.Core.Models;
using ECommerce_Standard_.EcommerceAppAPI.Services.Interfaces;
using ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces;

namespace ECommerce_Standard_.EcommerceAppAPI.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepsitory;

        public OrderService(IOrderRepository orderRepsitory)
        {
            _orderRepsitory = orderRepsitory;
        }

        public async Task<bool> AddUserOrder(int userId, List<Product> products)
        {
            var isAdded = await _orderRepsitory.AddUserOrder(userId, products);
            if (!isAdded)
            {
                return false;
            }
            return true;
        }
        public async Task<List<OrderResponse>> GetUserOrders(int userId)
        {
            var orders = await _orderRepsitory.GetUserOrders(userId);
            if (!orders.Any())
            {
                return null;
            }
            return orders;
        }
    }
}
