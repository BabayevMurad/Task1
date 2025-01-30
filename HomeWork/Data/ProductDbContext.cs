using HomeWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            :base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
