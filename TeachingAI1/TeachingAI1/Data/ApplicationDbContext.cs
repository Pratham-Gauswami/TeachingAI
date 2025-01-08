using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TeachingAI1.Models;

namespace TeachingAI1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Activity> Activities { get; set; }
		public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Teacher relationships
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);

            modelBuilder.Entity<Activity>()
                .HasOne(a => a.Teacher)
                .WithMany(t => t.Activities)
                .HasForeignKey(a => a.TeacherId);

            // Student-Course many-to-many relationship
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.Students)
                .UsingEntity(j => j.ToTable("StudentCourses"));

            // Student-Assignment many-to-many relationship
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Assignments)
                .WithMany(a => a.Students)
                .UsingEntity(j => j.ToTable("StudentAssignments"));
        }
    }
}
