using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ÄPI.Infrastructure.CustomAttributes
{
    public class CurrencySymbolFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string symbol = value.ToString();
                string pattern = @"^[A-Z]+$"; //Currencies symbols REGex. => Only letter, only MAYUSC.

                if (!Regex.IsMatch(symbol, pattern))
                {
                    return new ValidationResult(ErrorMessage ?? "Currency symbols allow only letters and they must be on MAYUSC.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
