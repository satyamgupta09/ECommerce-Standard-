using ECommerce_Standard_.EcommerceApp.Core.Models;

namespace ECommerce_Standard_.EcommerceAppAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);

    }
}
