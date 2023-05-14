using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ReactAspCrud.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]  public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
       // [JsonIgnore]
       // public Sales Sales { get; set; }
       
    }
}
