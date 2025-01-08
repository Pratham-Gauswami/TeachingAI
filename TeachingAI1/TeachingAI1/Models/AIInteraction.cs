using System.Collections.Generic;

namespace TeachingAI1.Models
{
public class AIInteraction
{
    public int Id { get; set; }
    public int UserId { get; set; } // Student or teacher interacting with AI
    public User User { get; set; }
    public string Input { get; set; } // Question or topic entered by the user
    public string AIResponse { get; set; }
    public DateTime Timestamp { get; set; }
}
}