using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeachingAI1.ViewModels;

namespace TeachingAI1.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Student name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        
        public int EnrolledCourses { get; set; }
        
        public int OverallProgress { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }
        
        // Navigation properties
        public List<CourseViewModel> Courses { get; set; }
    }
} 