using ÄPI.Infrastructure.CustomAttributes;

namespace ÄPI.DTOs.User
{
    public class UserAdd_DTO //This DTO creates both the user and his/her respective credentials.
    {
        [DNIFormat]
        public int DNI { get; set; }

        [OnlyNumberFormat]
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Genre { get; set; }


        //Credentials props

        [EmailFormat]
        public string Email { get; set; }

        [PasswordFormat]
        public string Password { get; set; }
    }
}
