using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeachingAI1.Models
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Course title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; }
        
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters")]
        public string Description { get; set; }
        
        public int EnrolledStudents { get; set; }
        
        public string Duration { get; set; }
        
        public int Attendance { get; set; }
        
        public int Completion { get; set; }
        
        public double Rating { get; set; }
        
        public string Status { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        
        public string Syllabus { get; set; }
        
        // For student course progress
        public int Progress { get; set; }
        
        public string Grade { get; set; }
        
        // Navigation properties
        public List<StudentViewModel> Students { get; set; }
        
        public List<AssignmentViewModel> Assignments { get; set; }
    }
} 