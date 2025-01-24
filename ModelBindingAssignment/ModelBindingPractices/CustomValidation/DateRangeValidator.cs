
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelBindingPractices.CustomValidation
{
    public class DateRangeValidator: ValidationAttribute
    {
        private readonly string otherPropertyName;

        public DateRangeValidator(string otherPropertyName)
        {
            this.otherPropertyName = otherPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return null;
            var toDate = Convert.ToDateTime(value);
            PropertyInfo? property = validationContext.ObjectType.GetProperty(otherPropertyName);
            if (property != null)
            {
                DateTime fromDate = Convert.ToDateTime(property.GetValue(validationContext.ObjectInstance));
                if(fromDate > toDate)
                {
                    return new ValidationResult(ErrorMessage, new String[] { otherPropertyName, validationContext.MemberName! });
                }
                return ValidationResult.Success;
            }
            return null;

        }
    }
}
