using ECommerce_Standard_.EcommerceApp.Core.Models;
using ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces;
using MySqlConnector;
using static System.Net.Mime.MediaTypeNames;


namespace ECommerce_Standard_.EcommerveApp.API.Respositeries.Implmentation
{
    public class ProductRepository: IProductRepository
    {
        //private readonly IProductRepository _productRepository;

        //public ProductRepository(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}
        private readonly string _connectionString;

        public ProductRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }


        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = new List<Product>();

            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            using var command = new MySqlCommand("SELECT * FROM Products", conn);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                products.Add(new Product
                {
                    id = reader.GetInt32("id"),
                    title = reader["title"] == DBNull.Value ? null : reader.GetString("title"),
                    description = reader["description"] == DBNull.Value ? null : reader.GetString("description"),
                    price = reader.GetDecimal("price"),
                    discountPercentage = reader.GetDecimal("discountPercentage"),
                    rating = reader.GetDecimal("rating"),
                    stock = reader.GetInt32("stock"),
                    brand = reader["brand"] == DBNull.Value ? null : reader.GetString("brand"),
                    category = reader["category"] == DBNull.Value ? null : reader.GetString("category"),
                    thumbnail = reader["thumbnail"] == DBNull.Value ? null : reader.GetString("thumbnail"),
                    images = reader.GetString("images").Split(',').ToList(),
                    tags = reader["tags"] == DBNull.Value ? new List<string>() : reader.GetString("tags").Split(',').ToList(),
                    weight = reader.GetInt32("weight"),
                    dimension_width = reader.GetDecimal("dimensions_width"),
                    dimension_height = reader.GetDecimal("dimensions_height"),
                    dimension_length = reader.GetDecimal("dimensions_depth")
                });
            }
            return products;
        }

        public async Task<Product> GetProductById(int id)
        {
            Product product = null;

            using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync();

            using var command = new MySqlCommand("SELECT * FROM products WHERE id = @id", conn);
            command.Parameters.AddWithValue("@id", id);  // ✅ FIX

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                product = new Product
                {
                    id = reader.GetInt32("id"),
                    title = reader["title"] == DBNull.Value ? null : reader.GetString("title"),
                    description = reader["description"] == DBNull.Value ? null : reader.GetString("description"),
                    price = reader.GetDecimal("price"),
                    discountPercentage = reader.GetDecimal("discountPercentage"),
                    rating = reader.GetDecimal("rating"),
                    stock = reader.GetInt32("stock"),
                    brand = reader["brand"] == DBNull.Value ? null : reader.GetString("brand"),
                    category = reader["category"] == DBNull.Value ? null : reader.GetString("category"),
                    thumbnail = reader["thumbnail"] == DBNull.Value ? null : reader.GetString("thumbnail"),
                    images = reader.GetString("images").Split(',').ToList(),
                    tags = reader["tags"] == DBNull.Value ? new List<string>() : reader.GetString("tags").Split(',').ToList(),
                    weight = reader.GetInt32("weight"),
                    dimension_width = reader.GetDecimal("dimensions_width"),
                    dimension_height = reader.GetDecimal("dimensions_height"),
                    dimension_length = reader.GetDecimal("dimensions_depth")
                };
            }

            return product;
        }
    }
}