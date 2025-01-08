using System.Collections.Generic;

namespace TeachingAI1.Models
{
public class Lesson
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; } // Could include text, videos, or links
    public int CourseId { get; set; } // Foreign Key for the course
    public Course Course { get; set; }
    public ICollection<Quiz> Quizzes { get; set; } // Optional quizzes for the lesson
}
}