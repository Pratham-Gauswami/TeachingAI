using System.Collections.Generic;

namespace TeachingAI1.Models
{
public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }  // "Active", "Inactive", etc.
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public ICollection<Student> Students { get; set; }
}
}