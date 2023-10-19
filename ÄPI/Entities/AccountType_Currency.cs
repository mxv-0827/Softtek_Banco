using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÄPI.Entities
{
    public class AccountType_Currency //Linking table between 'Currency' and 'AccountType' that shows which currencies are accepted for each account type.
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int AccountTypeID { get; set; }

        [Required]
        public int CurrencyID { get; set; }


        //Navigation props.

        [ForeignKey("AccountTypeID")]
        public AccountType AccountType { get; set; }

        [ForeignKey("CurrencyID")]
        public Currency Currency { get; set; }
    }
}
