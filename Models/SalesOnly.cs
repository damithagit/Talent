using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReactAspCrud.Models
{
    public class SalesOnly
    {
        [Key] public int SalesId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int StoreId { get; set; }
        public DateOnly DateSold { get; set; }
        public int Quantity { get; set; }
    }
}
