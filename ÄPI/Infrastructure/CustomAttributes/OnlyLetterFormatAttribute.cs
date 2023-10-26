using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ÄPI.Infrastructure.CustomAttributes
{
    public class OnlyLetterFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string amount = value.ToString();
                string pattern = @"^[A-Za-z\s]+$"; //Letters only REGex.

                if (!Regex.IsMatch(amount, pattern))
                {
                    return new ValidationResult(ErrorMessage ?? "Only letters allowed.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
