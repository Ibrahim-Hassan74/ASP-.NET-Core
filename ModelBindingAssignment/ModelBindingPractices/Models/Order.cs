using System.ComponentModel.DataAnnotations;

namespace ModelBindingPractices.Models
{
    public class Order : IValidatableObject
    {
        public int? OrderNo { get; set; }
        [Required]
        public DateTime? OrderDate { get; set; }
        [Required]
        public double? InvoicePrice { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OrderDate < Convert.ToDateTime("2000-01-01"))
                yield return new ValidationResult("The Date Must be greater than or equal to 2000-01-01");
        }
    }
}
