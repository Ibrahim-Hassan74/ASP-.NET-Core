using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ModelBindingPractices.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingPractices.Models
{
    public class Person: IValidatableObject
    {
        //[BindNever]
        [Required(ErrorMessage = "{0} must be inculed")]
        [Display(Name = "Person Id")]
        public int? Id { get; set; }
        [Required]
        [Display(Name = "Person Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1}")]
        [RegularExpression(@"^[A-Za-z .]+$", ErrorMessage = "The {0} must contain only alphabets, spaces, and periods.")]
        public string? PersonName { get; set; }
        [Range(minimum: 18, maximum: 60, ErrorMessage = "{0} must be between {1} and {2}")]
        public int? Age { get; set; }
        [Phone(ErrorMessage = "{0} field is not valid format")]
        public string? Phone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "{0} is not valid email format")]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "{0} must be equal to {1}")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }
        [MinimunYearValidator()]
        public DateTime? DateOfBirth { get; set; }
        public DateTime? FromDate { get; set; }
        [DateRangeValidator("FromDate", ErrorMessage = "'From Date' Should be older than or equal to 'To Date'")]
        public DateTime? ToDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Age.HasValue && !DateOfBirth.HasValue)
                yield return new ValidationResult("Either of Age or Date of birth must be supplied", new[] { nameof(Age) });
        }
    }
}
