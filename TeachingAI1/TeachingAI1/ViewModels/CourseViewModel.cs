using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeachingAI1.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public int EnrolledStudents { get; set; }
        
        public string Duration { get; set; }
        
        public int Attendance { get; set; }
        
        public int Completion { get; set; }
        
        public double Rating { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        
        public string Syllabus { get; set; }
        
        public bool PublishImmediately { get; set; } = true;

        // For student course progress
        public int Progress { get; set; }
        
        // For student course grade
        public string Grade { get; set; }

        // This property is only used for model binding in forms
        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Course Name is required")]
        public string Name { get; set; }
        
        // Constructor to initialize properties with default values
        public CourseViewModel()
        {
            Title = string.Empty;
            Description = string.Empty;
            Duration = "12 Weeks";
            Status = "Active";
            Syllabus = string.Empty;
            Grade = string.Empty;
            Name = string.Empty;
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddMonths(3);
        }
    }
} 