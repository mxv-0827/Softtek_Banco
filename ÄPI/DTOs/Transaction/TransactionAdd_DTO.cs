namespace ÄPI.DTOs.Transaction
{
    public class TransactionAdd_DTO
    {
        public int? OriginAccountID { get; set; }
        public int? DestinationAccountID { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
    }
}
