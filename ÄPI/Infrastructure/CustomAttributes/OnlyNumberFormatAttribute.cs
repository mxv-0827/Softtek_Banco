using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ÄPI.Infrastructure.CustomAttributes
{
    public class OnlyNumberFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string fullname = value.ToString();
                string pattern = @"^(?!0$)\d+$"; //Numbers only REGex.

                if (!Regex.IsMatch(fullname, pattern))
                {
                    return new ValidationResult(ErrorMessage ?? "Only numbers allowed except for 0 alone.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
