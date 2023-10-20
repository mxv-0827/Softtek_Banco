using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÄPI.Entities
{
    public class Account
    {
        [Key]
        public int AccountNumber { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Alias { get; set; }

        [Required]
        public int AccountTypeID { get; set; }

        [Required]
        public int CurrencyID { get; set; }

        [Required]
        public int Balance { get; set; }

        public string? CBU { get; set; } //Not 'Required' since it can be a crypto type of account, which does not have this prop.
        public string? UUID { get; set; } //Not 'Required' since it can be a fiduciary type of account, which does not have this prop.


        //Navigation props.

        [ForeignKey("UserID")]
        public User User { get; set; } //An account must have only one owner.

        [ForeignKey("AccountTypeID")]
        public AccountType AccountType { get; set; } //An account must only belong to one category.

        [ForeignKey("CurrencyID")]
        public Currency Currency { get; set; } //An account must only have one currency only.


        [InverseProperty("OriginAccount")]
        public virtual ICollection<Transaction> TransactionsOrigin { get; set; } //A user may make multiple transactions FROM a same account.

        [InverseProperty("ReceivingAccount")]
        public virtual ICollection<Transaction> TransactionsDestination { get; set; } //A user may make multiple transactions TO a same account.
    }
}
