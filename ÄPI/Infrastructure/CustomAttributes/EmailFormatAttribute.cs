using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ÄPI.Infrastructure.CustomAttributes
{
    public class EmailFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();
                string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$"; //Email REGex.

                if (!Regex.IsMatch(email, pattern))
                {
                    return new ValidationResult(ErrorMessage ?? "Invalid email format.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
