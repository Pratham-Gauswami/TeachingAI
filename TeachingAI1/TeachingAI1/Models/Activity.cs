namespace TeachingAI1.Models
{
public class Activity
{
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }  // "Assignment Created", "Grade Posted", etc.
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
} 
}