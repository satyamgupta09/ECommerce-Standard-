namespace ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces
using ECommerce_Standard_.EcommerceApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

{
    public interface IProductRepository
    public class IProductRepository
{
    public Task<IEnumerable<Product>> GetAllProducts();
    public Task<Product?> GetProductById(int productId);
}
}