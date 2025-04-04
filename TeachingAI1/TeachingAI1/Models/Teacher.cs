using System.Collections.Generic;

public class Teacher
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    // Navigation property
    public User User { get; set; }
    
    // Collection of courses taught by this teacher
    public ICollection<Course> Courses { get; set; } = new List<Course>();
} 