using Microsoft.EntityFrameworkCore;

namespace ReactAspCrud.Models
{
    public class ProductsDbContext
    {

        public ProductsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-2EDOGVGN;Initial Catalog=StoreSales;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}


