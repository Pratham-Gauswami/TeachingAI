using Microsoft.EntityFrameworkCore;

namespace TeachingAI1.Data
{
public class ApplicationDbContext : DbContext
{
    // Constructor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // Define DbSets for your entities
	public DbSet<User>? Users {get; set;}
	public DbSet<Progress>? Progresses {get; set;}
	public DbSet<Feedback>? Feedbacks {get; set;}
	public DbSet<Lesson>? Lessons {get; set;}
	public DbSet<Course>? Courses {get; set;}
	public DbSet<Quiz>? Quizzes {get; set;}
	public DbSet<AIInteraction>? AIInteractions {get; set;}
	
}
}
