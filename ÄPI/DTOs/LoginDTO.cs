using ÄPI.Infrastructure.CustomAttributes;

namespace ÄPI.DTOs
{
    public class LoginDTO
    {
        [EmailFormat]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
