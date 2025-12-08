using ECommerce_Standard_.EcommerceApp.Core.DTOs.response;
using ECommerce_Standard_.EcommerceApp.Core.Models;
using ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces;
using MySqlConnector;

namespace ECommerce_Standard_.EcommerveApp.API.Respositeries.Implmentation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionstring;

        public OrderRepository(IConfiguration config)
        {
            _connectionstring = config.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> AddUserOrder(int userId, List<Product> products)
        {
            using var conn = new MySqlConnection(_connectionstring);
            await conn.OpenAsync();

            try
            {
                foreach (var product in products)
                {
                    var query = @"INSERT INTO orders (userId, productId, orderDate, totalAmount)
                                VALUES (@userId, @productId, @orderDate, @totalAmount)";


                    using var command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@productId", product.id);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@orderDate", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@totalAmount", product.price);

                    await command.ExecuteNonQueryAsync();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<OrderResponse>> GetUserOrders(int userId)
        {
            using var conn = new MySqlConnection(_connectionstring);
            await conn.OpenAsync();

            var products = new List<OrderResponse>();

            var query = @"
                SELECT 
                    o.productId,
                    o.orderDate,
                    o.totalAmount,
                    p.id,
                    p.title,
                    p.description,
                    p.price,
                    p.thumbnail
                FROM orders o
                JOIN products p ON o.productId = p.id
                WHERE o.userId = @userId";

            using var command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@userId", userId);

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var product = new OrderResponse
                {
                    id = reader.GetInt32("id"),
                    productId = reader.GetInt32("productId"),
                    title = reader.GetString("title"),
                    description = reader.GetString("description"),
                    price = reader.GetDecimal("price"),
                    thumbnail = reader.GetString("thumbnail"),

                    // ORDER FIELDS
                    orderDate = reader.GetDateTime("orderDate"),
                    totalAmount = reader.GetDecimal("totalAmount")
                };

                products.Add(product);
            }

            return products;
        }
    }
}
