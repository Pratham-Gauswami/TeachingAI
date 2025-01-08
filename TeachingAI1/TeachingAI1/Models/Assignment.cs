using System;
using System.Collections.Generic;

namespace TeachingAI1.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DueDate { get; set; }
        public int CourseId { get; set; }

        // Navigation properties
        public Course Course { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}