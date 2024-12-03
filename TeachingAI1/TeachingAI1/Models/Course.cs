public class Course
{
    public int courseID {get; set;}

    public string courseName {get; set;}
    public string Description {get; set;}
    public int TeacherId {get; set;} //Foreign Key for the Teacher
    public User Teacher {get; set;}
    public DateTime CreatedOn {get; set;}
    public ICollection<Lesson> Lessons {get; set;} //A course can have multiple lessons
}