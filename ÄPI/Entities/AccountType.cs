using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÄPI.Entities
{
    public class AccountType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        public string Description { get; set; }


        //Navigation props.
        public ICollection<Account> Accounts { get; set; } //Many accounts may belong to a same category.
        public ICollection<AccountType_Currency> AccountType_Currencies { get; set; } //Many currencies allowed in one type of account => 'Cryptos allows Bitcoin, Ethereum, etc'
    }
}
