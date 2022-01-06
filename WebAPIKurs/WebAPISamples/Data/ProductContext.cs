using Microsoft.EntityFrameworkCore;
using WebAPISamples.Models;

namespace WebAPISamples.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
