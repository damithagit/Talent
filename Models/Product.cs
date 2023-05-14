using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ReactAspCrud.Models
{
    public class Product
    {
        [Key] public int ProductId { get; set; }
        public string Name { get; set; }    
        public decimal Price { get; set; }
        

    }
}
