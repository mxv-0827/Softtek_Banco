using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÄPI.Entities
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        public int? SourceAccount { get; set; } //Not 'Required' due to the possibility of making deposits, which have no source account.
        public int? DestinationAccount { get; set; } //Not 'Required' due to the possibility of making withdrawals, which have no destination account.

        [Required]
        [Column("TransactionType", TypeName = "VARCHAR(50)")]
        public string Type { get; set; }

        [Required]
        public int CurrencyID { get; set; }

        [Required]
        public int Amount { get; set; }


        //Navigation props.

        [ForeignKey("SourceAccount")]
        public Account OriginAccount { get; set; } //A transaction must only be produced by one account.

        [ForeignKey("DestinationAccount")]
        public Account ReceivingAccount { get; set; } //A transaction must only be produced to one account.

        public Currency Currency { get; set; } //A transaction must be made in only one currency.
    }
}
