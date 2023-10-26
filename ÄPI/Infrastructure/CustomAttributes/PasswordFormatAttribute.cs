using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ÄPI.Infrastructure.CustomAttributes
{
    public class PasswordFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string password = value.ToString();
                string pattern = @"^(?=.*[A-Z])(?=.*\d).{6,}$"; //Password REGex => 6 characters, 1 MAYUSC, 1 number.

                if (!Regex.IsMatch(password, pattern))
                {
                    return new ValidationResult(ErrorMessage ?? "The password must have at least 6 characters which must include a capital letter and a number.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
