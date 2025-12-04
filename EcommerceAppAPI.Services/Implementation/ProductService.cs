using ECommerce_Standard_.EcommerceApp.Core.Models;
using ECommerce_Standard_.EcommerceAppAPI.Services.Interfaces;
using ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces;

namespace ECommerce_Standard_.EcommerceAppAPI.Services.Implementation
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _repo.GetAllProducts();
            if(products == null)
            {
                throw new Exception("No products found");   
            }
            return products;
        }

        public async Task<Product?> GetProductById(int id)
        {
            var product = await _repo.GetProductById(id);
            if(product == null)
            {
                throw new Exception("Product not found");
            }
            return product;
        }

    }
}
