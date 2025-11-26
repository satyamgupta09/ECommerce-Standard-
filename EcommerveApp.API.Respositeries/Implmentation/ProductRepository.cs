using ECommerce_Standard_.EcommerceApp.Core.Models;
using ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces;
using MySqlConnector;

namespace ECommerce_Standard_.EcommerveApp.API.Respositeries.Implmentation

namespace ECommerce_Standard_.EcommerveApp.API.Respositeries.Implmentation
{
    public class ProductRepository
    public interface ProductRepository
    {
        private readonly IProductRepository _productRepository;

        public ProductRepository(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = new List<Product>();

            using var conn = new MySqlConnection("YourConnectionStringHere");
            await conn.OpenAsync();

            using var command = new MySqlCommand("SELECT * FROM Products", conn);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                products.Add(new Product
                {
                    id = reader.GetInt32("id"),
                    title = reader.GetString("title"),
                    description = reader.GetString("description"),
                    price = reader.GetDecimal("price"),
                    discountPercentage = reader.GetDecimal("discountPercentage"),
                    rating = reader.GetDecimal("rating"),
                    stock = reader.GetInt32("stock"),
                    brand = reader.GetString("brand"),
                    category = reader.GetString("category"),
                    thumbnail = reader.GetString("thumbnail"),
                    // Assuming images and tags are stored as comma-separated strings
                    images = reader.GetString("images").Split(',').ToList(),
                    tags = reader.GetString("tags").Split(',').ToList(),
                    weigth = reader.GetInt32("weigth"),
                    dimension_width = reader.GetDecimal("dimension_width"),
                    dimension_height = reader.GetDecimal("dimension_height"),
                    dimension_length = reader.GetDecimal("dimension_length")
                });
            }
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            Product product = null;
            using var conn = new MySqlConnection("YourConnectionStringHere");
            await conn.OpenAsync();
            using var command = new MySqlCommand("SELECT * FROM products WHERE Id = @id", conn);
            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                product = new Product
                {
                    id = reader.GetInt32("id"),
                    title = reader.GetString("title"),
                    description = reader.GetString("description"),
                    price = reader.GetDecimal("price"),
                    discountPercentage = reader.GetDecimal("discountPercentage"),
                    rating = reader.GetDecimal("rating"),
                    stock = reader.GetInt32("stock"),
                    brand = reader.GetString("brand"),
                    category = reader.GetString("category"),
                    thumbnail = reader.GetString("thumbnail"),
                    // Assuming images and tags are stored as comma-separated strings
                    images = reader.GetString("images").Split(',').ToList(),
                    tags = reader.GetString("tags").Split(',').ToList(),
                    weigth = reader.GetInt32("weigth"),
                    dimension_width = reader.GetDecimal("dimension_width"),
                    dimension_height = reader.GetDecimal("dimension_height"),
                    dimension_length = reader.GetDecimal("dimension_length")
                };
            }
            return product;
        }
    }
}