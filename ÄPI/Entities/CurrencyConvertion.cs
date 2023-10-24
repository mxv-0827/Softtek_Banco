using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ÄPI.Entities
{
    public class CurrencyConvertion
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int From_Currency { get; set; }

        [Required]
        public int To_Currency { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 10)")]
        public decimal Price { get; set; }


        //Navigation props.

        [ForeignKey("From_Currency")]
        [InverseProperty("From_CurrenciesConvertions")]
        public Currency Currency_From { get; set; }

        [ForeignKey("To_Currency")]
        [InverseProperty("To_CurrenciesConvertions")]
        public Currency Currency_To { get; set; }
    }
}
