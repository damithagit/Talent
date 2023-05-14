using System.ComponentModel.DataAnnotations;

namespace ReactAspCrud.Models
{
    public class Store
    {
        [Key]public int StoreId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        //public virtual ICollection<Store> Stores { get; set; }
    }
}
