namespace ÄPI.DTOs.Transaction
{
    public class TransactionGet_DTO
    {
        public int TransactionNumber { get; set; }
        public int AccountNumber { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
    }
}
