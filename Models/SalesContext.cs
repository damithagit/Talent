using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ReactAspCrud.Models
{
    public class SalesContext : DbContext
    {

        public SalesContext(DbContextOptions options) : base(options)
        { }


      
        public DbSet<Sales> Sales { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-2EDOGVGN;Initial Catalog=StoreSales;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
        

