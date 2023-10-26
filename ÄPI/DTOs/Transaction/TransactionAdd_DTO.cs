using ÄPI.Infrastructure.CustomAttributes;

namespace ÄPI.DTOs.Transaction
{
    public class TransactionAdd_DTO
    {
        [OnlyNumberFormat]
        public int? OriginAccountID { get; set; }

        [OnlyNumberFormat]
        public int? DestinationAccountID { get; set; }

        [OnlyLetterFormat]
        public string TransactionType { get; set; }

        [OnlyNumberFormat]
        public decimal Amount { get; set; }
    }
}
