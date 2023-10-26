using ÄPI.Infrastructure.CustomAttributes;

namespace ÄPI.DTOs
{
    public class ConvertionValueDTO
    {
        [CurrencySymbolFormat]
        public string From_Currency { get; set; }

        [CurrencySymbolFormat]
        public string To_Currency { get; set; }

        [OnlyLetterFormat]
        public int Amount { get; set; }
    }
}
