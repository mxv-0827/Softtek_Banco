using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÄPI.Entities
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int AccountID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(40)")]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 10)")]
        public decimal Amount { get; set; }

        
        //Navigation props.

        [ForeignKey("AccountID")]
        public Account Account { get; set; } //A transaction must only be produced by one account.
    }
}
