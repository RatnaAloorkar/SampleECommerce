using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleECommerce.Models
{
    public class Order
    {
        [Required]
        public List<Product> Products { get; set; }
        [Required]
        public int CountryId { get; set; }
        [Required]
        public float ShippingCost { get; set; }
        [Required]
        public float SubTotal { get; set; }
        [Required]
        public float Total { get; set; }

    }
}
