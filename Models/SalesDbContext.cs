using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ReactAspCrud.Models
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesOnly> SalesOnly { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Data Source=LAPTOP-2EDOGVGN;Initial Catalog=StoreSales;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
           // optionsBuilder.UseSqlServer("Data Source =LAPTOP-2EDOGVGN; Initial Catalog = Stores; Integrated Security = True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
       
       
    }
}
