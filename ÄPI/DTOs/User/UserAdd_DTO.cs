namespace ÄPI.DTOs.User
{
    public class UserAdd_DTO //This DTO creates both the user and his/her respective credentials.
    {
        public int DNI { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Genre { get; set; }


        //Credentials props

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
