using System.Collections.Generic;

namespace TeachingAI1.Models
{
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } // e.g., "Teacher", "Student", "Admin"

    public bool IsLoggedIn { get; set; } 

    public DateTime? LastActivity { get; set; }
    public DateTime CreatedAt { get; set; }
}
}