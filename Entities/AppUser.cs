using Microsoft.AspNetCore.Identity;

namespace Herba.Entities
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
    }
}
