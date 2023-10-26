using ÄPI.Infrastructure.CustomAttributes;

namespace ÄPI.DTOs.Credentials
{
    public class CredentialsUpdate_DTO
    {
        [EmailFormat]
        public string Email { get; set; }

        [PasswordFormat]
        public string NewPassword { get; set; }
    }
}
