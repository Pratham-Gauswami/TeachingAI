using System;
using System.Collections.Generic;

namespace TeachingAI1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }  // "Active", "Inactive", etc.

        // Navigation properties
        public ICollection<Course> Courses { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        
        // Optional: Add properties for tracking student progress
        public decimal AverageGrade { get; set; }
        public int CompletedAssignments { get; set; }
    }
} 