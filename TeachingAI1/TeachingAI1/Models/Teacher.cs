using System.Collections.Generic;

namespace TeachingAI1.Models
{
    public class Teacher
    {
        public Teacher()
        {
            Courses = new List<Course>();
            Activities = new List<Activity>();
            Name = string.Empty;
            Email = string.Empty;
            PasswordHash = string.Empty;
        }
        
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }

        // Navigation properties
        public ICollection<Course> Courses { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
} 