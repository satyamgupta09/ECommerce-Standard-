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

            var command = new MySqlCommand("SELECT itemsIds FROM Cart WHERE userId = @userId", conn);
            command.Parameters.AddWithValue("@userId", userId);

            var reader = await command.ExecuteReaderAsync();
            List<Product> products = new List<Product>();

            while(await reader.ReadAsync())
            {
                var itemsIdsString = reader["itemsIds"].ToString();
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

        public async Task<bool> AddToCart(int userId, int itemId)
        {
            var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            var command = new MySqlCommand(
    "INSERT INTO Cart(userId, itemId) " +
    "SELECT @userId, @itemId " +
    "WHERE NOT EXISTS (SELECT 1 FROM Cart WHERE userId = @userId)", conn);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@itemId", itemId);

            var reader = await command.ExecuteReaderAsync();

            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }
    }
}
