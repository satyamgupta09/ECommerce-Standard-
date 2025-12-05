
using ECommerce_Standard_.EcommerceApp.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce_Standard_.EcommerveApp.API.Respositories.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> products { get; set; }
    }
}
