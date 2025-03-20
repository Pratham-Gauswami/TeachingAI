public class Quiz
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; } // Correct answer
    public ICollection<string> Options { get; set; } // Multiple-choice options
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; }
}
