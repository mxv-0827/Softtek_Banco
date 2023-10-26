using ÄPI.Infrastructure.CustomAttributes;

namespace ÄPI.DTOs.Account
{
    public class AccountAdd_DTO
    {
        public string Alias { get; set; }

        [OnlyLetterFormat]
        public string AccountType { get; set; }

        [CurrencySymbolFormat]
        public string Currency { get; set; }
    }
}
