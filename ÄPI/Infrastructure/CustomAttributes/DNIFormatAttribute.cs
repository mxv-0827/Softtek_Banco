using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ÄPI.Infrastructure.CustomAttributes
{
    public class DNIFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string dni = value.ToString();
                string pattern = @"^\d{8}$"; //DNI REGex.

                if (!Regex.IsMatch(dni, pattern))
                {
                    return new ValidationResult(ErrorMessage ?? "Invalid DNI format.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
