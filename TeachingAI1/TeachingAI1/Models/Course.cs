public class Course
{
    public int Id {get; set;}  // Primary key
    public string Name {get; set;} = string.Empty;  // Course name
    public int TeacherId {get; set;}  // Foreign key to Teacher
    public string Status {get; set;} = "Active";  // Status (Active, Draft, etc.)
    
    // Navigation property
    public User Teacher {get; set;}
    
    // Collections
    public ICollection<Lesson> Lessons {get; set;} = new List<Lesson>();
    
    // These properties don't exist in the database
    // They are commented out but kept for reference in case the database is updated later
    // public string Description {get; set;} = string.Empty;
    // public DateTime CreatedOn {get; set;} = DateTime.Now;
}