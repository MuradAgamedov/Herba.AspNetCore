using System.ComponentModel.DataAnnotations;

namespace Herba.Dtos.Auth
{
    public class LoginDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
