public class Feedback
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}
