using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÄPI.Entities
{
    public class Currency
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(30)")]
        public string Description { get; set; }


        //Navigation props.
        public ICollection<Account> Accounts { get; set; } //A currency may be present in more than one account at a time.
        public ICollection<AccountType_Currency> AccountType_Currencies { get; set; }

        public ICollection<CurrencyConvertion> From_CurrenciesConvertions { get; set; }
        public ICollection<CurrencyConvertion> To_CurrenciesConvertions { get; set; }
    }
}
