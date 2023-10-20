using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ÄPI.Entities
{
    public class Credentials
    {
        [Key]
        [Column("UserID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(75)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(250)")]
        public string Password { get; set; }


        //Navigation props.
        [ForeignKey("ID")]
        public User User { get; set; } //Only one user per account allowed.
    }
}
