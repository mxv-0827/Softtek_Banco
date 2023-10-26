using Swashbuckle.AspNetCore.Annotations;

namespace ÄPI.DTOs.Account
{
    public class AccountGet_DTO
    {
        public int AccountNumber { get; set; }
        public string Alias { get; set; }
        public string AccountType { get; set; }
        public string Currency { get; set; }

        public decimal Balance { get; set; }
        public string? CBU { get; set; }
        public string? UUID { get; set; }
    }
}
