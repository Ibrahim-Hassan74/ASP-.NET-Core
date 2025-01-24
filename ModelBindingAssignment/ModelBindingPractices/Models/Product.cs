using System.ComponentModel.DataAnnotations;

namespace ModelBindingPractices.Models
{
    public class Product
    {
        [Required]
        public int? ProdectCode { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int? Quantity { get; set; }

    }
}
