using Microsoft.AspNetCore.Identity;

namespace TeachingAI1.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; } // Add any additional properties you need
    }
}
