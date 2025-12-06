using ECommerce_Standard_.EcommerceApp.Core.Models;
using ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces;
using MySqlConnector;

namespace ECommerce_Standard_.EcommerveApp.API.Respositeries.Implmentation
{
    public class CartRepository: ICartRepository
    {
        private readonly string _connectionString;
        private readonly IProductRepository _productRepository;

        public CartRepository(IConfiguration config, IProductRepository productRepository)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetUserCart(int userId)
        {
            var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            var command = new MySqlCommand("SELECT productId FROM Cart WHERE userId = @userId", conn);
            //var command = new MySqlCommand("SELECT productId FROM Cart WH")
            command.Parameters.AddWithValue("@userId", userId);

            var reader = await command.ExecuteReaderAsync();
            List<Product> products = new List<Product>();

            while(await reader.ReadAsync())
            {
                var itemsIdsString = reader["productId"].ToString();
                var productIds = itemsIdsString?.Split(',').Select(id => int.Parse(id)).ToList();

                foreach(var prodId in productIds)
                {
                    var product = await _productRepository.GetProductById(prodId);
                    if(product != null)
                    {
                        products.Add(product);
                    }
                }
            }
            return products;
        }

        public async Task<bool> AddToCart(int userId, int productId)
        {
            var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            var command = new MySqlCommand(
    "INSERT INTO Cart(userId, productId, qty) " +
    "SELECT @userId, @productId, 1 " +
    "WHERE NOT EXISTS (SELECT 1 FROM Cart WHERE userId = @userId AND productId = @productId)", conn);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@productId", productId);

            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }

        public async Task<bool> IncreaseQty(int userId, int productId)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            var command = new MySqlCommand("UPDATE Cart SET qty = qty + 1 WHERE userId = @userId and productId = @productId", conn);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@productId", productId);

            var rowAffected = await command.ExecuteNonQueryAsync();

            return rowAffected > 0;
        }

        public async Task<bool> DecreaseQty(int userId, int productId)
        {
            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            var command = new MySqlCommand("UPDATE Cart SET qty = qty - 1 WHERE userId = @userId and productId = @productId and qty > 1", conn);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@productId", productId);

            var rowAffected = await command.ExecuteNonQueryAsync();

            return rowAffected > 0;
        }

    }
}
