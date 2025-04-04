using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TeachingAI1.Data
{
public class ApplicationDbContext : DbContext
{
    // Constructor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) 
    { 
        // Ensure we have a teacher account
        EnsureTeacherAccountExists();
    }

    // Define DbSets for your entities
	public DbSet<User>? Users {get; set;}
	public DbSet<Progress>? Progresses {get; set;}
	public DbSet<Feedback>? Feedbacks {get; set;}
	public DbSet<Lesson>? Lessons {get; set;}
	public DbSet<Course>? Courses {get; set;}
	public DbSet<Quiz>? Quizzes {get; set;}
	public DbSet<AIInteraction>? AIInteractions {get; set;}
	public DbSet<Teacher>? Teachers {get; set;}
	
    // Configure entity relationships
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configure Course-Teacher relationship
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Teacher)
            .WithMany(t => t.Courses)  // Use the collection on Teacher
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
            
        // Configure Teacher-User relationship
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.User)
            .WithMany()  // No navigation property from User to Teacher
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void EnsureTeacherAccountExists()
    {
        try
        {
            // Check if we need to migrate the database
            if (this.Database.GetPendingMigrations().Any())
            {
                return; // Skip seeding if migrations are pending
            }

            // Check if we have a teacher account already
            if (Users != null && !Users.Any(u => u.Role == "Teacher"))
            {
                // Add a test teacher account
                var teacherUser = new User
                {
                    Id = 1, // Force ID to be 1
                    Name = "Test Teacher",
                    Email = "teacher@example.com",
                    PasswordHash = "5f4dcc3b5aa765d61d8327deb882cf99", // "password" (MD5 hash for demo only)
                    Role = "Teacher",
                    CreatedAt = DateTime.Now
                };
                
                Users.Add(teacherUser);
                SaveChanges();
                
                // Also add a corresponding Teacher record
                if (Teachers != null && !Teachers.Any(t => t.Id == 1))
                {
                    var teacher = new Teacher
                    {
                        Id = 1,
                        UserId = teacherUser.Id
                    };
                    
                    Teachers.Add(teacher);
                    SaveChanges();
                }
            }
        }
        catch (Exception ex)
        {
            // Log the error but don't crash the application
            System.Diagnostics.Debug.WriteLine($"Error seeding teacher account: {ex.Message}");
        }
    }
}
}
