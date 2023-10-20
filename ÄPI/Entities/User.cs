using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÄPI.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public int DNI { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(100)")]
        public string Fullname { get; set; }

        [Required]
        [Column("DateOfBirth", TypeName = "DATE")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(25)")]
        public string Genre { get; set; }


        //Navigation props.
        public Credentials Credentials { get; set; } //Only one account per user allowed.
        public ICollection<Account> Accounts { get; set; } //A user may have multiple accounts.
    }
}
