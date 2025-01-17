using System.ComponentModel.DataAnnotations;

namespace ModelBindingPractices.CustomValidation
{
    public class MinimunYearValidatorAttribute : ValidationAttribute
    {
        private readonly int minimumYear = 2000;
        public string OtherErrorMessage { get; set; } = "Year Should not be less than {0}";
        public MinimunYearValidatorAttribute()
        {
        }

        public MinimunYearValidatorAttribute(int minimumYear)
        {
            this.minimumYear = minimumYear;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null) return null;
            DateTime date = (DateTime)value;
            if (date.Year < minimumYear) 
                return new ValidationResult(string.Format(ErrorMessage ?? OtherErrorMessage, minimumYear));
            return ValidationResult.Success;
        }
    }
}
