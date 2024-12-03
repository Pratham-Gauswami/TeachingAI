public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; } // e.g., "Teacher", "Student", "Admin"
    public DateTime CreatedAt { get; set; }
}