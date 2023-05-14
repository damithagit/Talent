using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace ReactAspCrud.Models
{
    public class Sales
    {
        
        [Key] public int SalesId { get; set; }
                        
       
       [ForeignKey("Customers")]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }
        [ForeignKey("Product")]
     //   [DatabaseGenerated(DatabaseGeneratedOption.None)]
         public int ProductId { get; set; }

       [ForeignKey("Stores")]
     //  [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        public int StoreId { get; set; }
        public DateOnly DateSold { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public  Customer Customers { get; set; }
        
        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Store Stores { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [JsonIgnore]
        //[NotMapped]
        public Product Products { get; set; }

        //public virtual ICollection<Customer> Customers { get; set; }
       // public virtual ICollection<Product> Products { get; set; }
        // public virtual ICollection<Store> Stores { get; set; }




    }
}
