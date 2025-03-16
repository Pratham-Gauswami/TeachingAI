using Microsoft.AspNetCore.Mvc;
using TeachingAI1.Models;
using System;
using System.Collections.Generic;

namespace TeachingAI1.Controllers
{
    public class Teacher : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            ViewData["ShowSearch"] = true;
            ViewData["Title"] = "Teacher Dashboard";
            
            // In a real application, this data would come from a database
            // For demo purposes, we're creating sample data
            ViewBag.ActiveCourses = 5;
            ViewBag.TotalStudents = 128;
            ViewBag.PendingAssignments = 12;
            ViewBag.NewMessages = 24;
            
            return View();
        }
        
        public IActionResult Courses()
        {
            ViewData["Title"] = "My Courses";
            
            // In a real application, this data would come from a database
            // For demo purposes, we're creating sample courses
            var courses = new List<CourseViewModel>
            {
                new CourseViewModel
                {
                    Id = 1,
                    Title = "Introduction to AI",
                    Description = "Learn the fundamentals of artificial intelligence and its applications.",
                    EnrolledStudents = 32,
                    Duration = "12 Weeks",
                    Attendance = 87,
                    Completion = 92,
                    Rating = 4.8,
                    Status = "Active",
                    StartDate = DateTime.Now.AddDays(-30),
                    EndDate = DateTime.Now.AddDays(60)
                },
                new CourseViewModel
                {
                    Id = 2,
                    Title = "Machine Learning Fundamentals",
                    Description = "Explore the core concepts of machine learning and data analysis.",
                    EnrolledStudents = 28,
                    Duration = "16 Weeks",
                    Attendance = 92,
                    Completion = 78,
                    Rating = 4.6,
                    Status = "Active",
                    StartDate = DateTime.Now.AddDays(-45),
                    EndDate = DateTime.Now.AddDays(75)
                },
                new CourseViewModel
                {
                    Id = 3,
                    Title = "Deep Learning Applications",
                    Description = "Advanced techniques in neural networks and deep learning.",
                    EnrolledStudents = 24,
                    Duration = "10 Weeks",
                    Attendance = 85,
                    Completion = 70,
                    Rating = 4.5,
                    Status = "Active",
                    StartDate = DateTime.Now.AddDays(-15),
                    EndDate = DateTime.Now.AddDays(55)
                },
                new CourseViewModel
                {
                    Id = 4,
                    Title = "Natural Language Processing",
                    Description = "Understanding and implementing NLP techniques.",
                    EnrolledStudents = 22,
                    Duration = "8 Weeks",
                    Attendance = 90,
                    Completion = 85,
                    Rating = 4.7,
                    Status = "Active",
                    StartDate = DateTime.Now.AddDays(-20),
                    EndDate = DateTime.Now.AddDays(40)
                },
                new CourseViewModel
                {
                    Id = 5,
                    Title = "Computer Vision",
                    Description = "Image processing and computer vision algorithms.",
                    EnrolledStudents = 20,
                    Duration = "10 Weeks",
                    Attendance = 88,
                    Completion = 80,
                    Rating = 4.4,
                    Status = "Active",
                    StartDate = DateTime.Now.AddDays(-25),
                    EndDate = DateTime.Now.AddDays(45)
                }
            };
            
            return View(courses);
        }
        
        public IActionResult CourseDetails(int id)
        {
            ViewData["Title"] = "Course Details";
            
            // In a real application, this would fetch the course from a database
            // For demo purposes, we're creating a sample course
            var course = new CourseViewModel
            {
                Id = id,
                Title = id == 1 ? "Introduction to AI" : "Machine Learning Fundamentals",
                Description = "Learn the fundamentals of artificial intelligence and its applications.",
                EnrolledStudents = id == 1 ? 32 : 28,
                Duration = id == 1 ? "12 Weeks" : "16 Weeks",
                Attendance = id == 1 ? 87 : 92,
                Completion = id == 1 ? 92 : 78,
                Rating = id == 1 ? 4.8 : 4.6,
                Status = "Active",
                StartDate = DateTime.Now.AddDays(-30),
                EndDate = DateTime.Now.AddDays(60),
                Syllabus = "Week 1: Introduction to AI\nWeek 2: Problem Solving\nWeek 3: Knowledge Representation\nWeek 4: Machine Learning Basics\nWeek 5: Neural Networks\nWeek 6: Natural Language Processing\nWeek 7: Computer Vision\nWeek 8: Robotics\nWeek 9: Ethics in AI\nWeek 10: Future of AI\nWeek 11: Project Work\nWeek 12: Final Presentations"
            };
            
            return View(course);
        }
        
        [HttpGet]
        public IActionResult CreateCourse()
        {
            ViewData["Title"] = "Create New Course";
            return View();
        }
        
        [HttpPost]
        public IActionResult CreateCourse(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                // For demo purposes, we'll just redirect to the courses page
                TempData["SuccessMessage"] = "Course created successfully!";
                return RedirectToAction("Courses");
            }
            
            ViewData["Title"] = "Create New Course";
            return View(model);
        }
        
        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            ViewData["Title"] = "Edit Course";
            
            // In a real application, this would fetch the course from a database
            // For demo purposes, we're creating a sample course
            var course = new CourseViewModel
            {
                Id = id,
                Title = id == 1 ? "Introduction to AI" : "Machine Learning Fundamentals",
                Description = "Learn the fundamentals of artificial intelligence and its applications.",
                EnrolledStudents = id == 1 ? 32 : 28,
                Duration = id == 1 ? "12 Weeks" : "16 Weeks",
                Status = "Active",
                StartDate = DateTime.Now.AddDays(-30),
                EndDate = DateTime.Now.AddDays(60),
                Syllabus = "Week 1: Introduction to AI\nWeek 2: Problem Solving\nWeek 3: Knowledge Representation\nWeek 4: Machine Learning Basics\nWeek 5: Neural Networks\nWeek 6: Natural Language Processing\nWeek 7: Computer Vision\nWeek 8: Robotics\nWeek 9: Ethics in AI\nWeek 10: Future of AI\nWeek 11: Project Work\nWeek 12: Final Presentations"
            };
            
            return View(course);
        }
        
        [HttpPost]
        public IActionResult EditCourse(CourseViewModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would update the database
                // For demo purposes, we'll just redirect to the course details page
                TempData["SuccessMessage"] = "Course updated successfully!";
                return RedirectToAction("CourseDetails", new { id = model.Id });
            }
            
            ViewData["Title"] = "Edit Course";
            return View(model);
        }
        
        public IActionResult Students()
        {
            ViewData["Title"] = "My Students";
            
            // In a real application, this data would come from a database
            // For demo purposes, we're creating sample students
            var students = new List<StudentViewModel>
            {
                new StudentViewModel
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    EnrolledCourses = 3,
                    OverallProgress = 85,
                    JoinDate = DateTime.Now.AddDays(-90)
                },
                new StudentViewModel
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    EnrolledCourses = 2,
                    OverallProgress = 92,
                    JoinDate = DateTime.Now.AddDays(-75)
                },
                new StudentViewModel
                {
                    Id = 3,
                    Name = "Michael Johnson",
                    Email = "michael.johnson@example.com",
                    EnrolledCourses = 4,
                    OverallProgress = 78,
                    JoinDate = DateTime.Now.AddDays(-120)
                },
                new StudentViewModel
                {
                    Id = 4,
                    Name = "Emily Davis",
                    Email = "emily.davis@example.com",
                    EnrolledCourses = 2,
                    OverallProgress = 95,
                    JoinDate = DateTime.Now.AddDays(-60)
                },
                new StudentViewModel
                {
                    Id = 5,
                    Name = "Robert Wilson",
                    Email = "robert.wilson@example.com",
                    EnrolledCourses = 3,
                    OverallProgress = 88,
                    JoinDate = DateTime.Now.AddDays(-100)
                }
            };
            
            return View(students);
        }
        
        public IActionResult StudentDetails(int id)
        {
            ViewData["Title"] = "Student Details";
            
            // In a real application, this would fetch the student from a database
            // For demo purposes, we're creating a sample student
            var student = new StudentViewModel
            {
                Id = id,
                Name = id == 1 ? "John Doe" : "Jane Smith",
                Email = id == 1 ? "john.doe@example.com" : "jane.smith@example.com",
                EnrolledCourses = id == 1 ? 3 : 2,
                OverallProgress = id == 1 ? 85 : 92,
                JoinDate = DateTime.Now.AddDays(-90),
                Courses = new List<CourseViewModel>
                {
                    new CourseViewModel
                    {
                        Id = 1,
                        Title = "Introduction to AI",
                        Progress = 90,
                        Grade = "A-"
                    },
                    new CourseViewModel
                    {
                        Id = 2,
                        Title = "Machine Learning Fundamentals",
                        Progress = 85,
                        Grade = "B+"
                    },
                    new CourseViewModel
                    {
                        Id = 3,
                        Title = "Deep Learning Applications",
                        Progress = 75,
                        Grade = "B"
                    }
                }
            };
            
            return View(student);
        }
        
        public IActionResult Assignments()
        {
            ViewData["Title"] = "Assignments";
            
            // In a real application, this data would come from a database
            // For demo purposes, we're creating sample assignments
            var assignments = new List<AssignmentViewModel>
            {
                new AssignmentViewModel
                {
                    Id = 1,
                    Title = "AI Ethics Case Study",
                    CourseTitle = "Introduction to AI",
                    DueDate = DateTime.Now.AddDays(1),
                    AssignedStudents = 32,
                    SubmittedCount = 18,
                    Status = "Upcoming"
                },
                new AssignmentViewModel
                {
                    Id = 2,
                    Title = "Neural Networks Project",
                    CourseTitle = "Machine Learning Fundamentals",
                    DueDate = DateTime.Now.AddDays(3),
                    AssignedStudents = 28,
                    SubmittedCount = 12,
                    Status = "Upcoming"
                },
                new AssignmentViewModel
                {
                    Id = 3,
                    Title = "Reinforcement Learning Implementation",
                    CourseTitle = "Deep Learning Applications",
                    DueDate = DateTime.Now.AddDays(7),
                    AssignedStudents = 24,
                    SubmittedCount = 5,
                    Status = "Upcoming"
                },
                new AssignmentViewModel
                {
                    Id = 4,
                    Title = "NLP Text Classification",
                    CourseTitle = "Natural Language Processing",
                    DueDate = DateTime.Now.AddDays(-2),
                    AssignedStudents = 22,
                    SubmittedCount = 20,
                    Status = "Past Due"
                },
                new AssignmentViewModel
                {
                    Id = 5,
                    Title = "Image Recognition Challenge",
                    CourseTitle = "Computer Vision",
                    DueDate = DateTime.Now.AddDays(-5),
                    AssignedStudents = 20,
                    SubmittedCount = 18,
                    Status = "Graded"
                }
            };
            
            return View(assignments);
        }
        
        public IActionResult AssignmentDetails(int id)
        {
            ViewData["Title"] = "Assignment Details";
            
            // In a real application, this would fetch the assignment from a database
            // For demo purposes, we're creating a sample assignment
            var assignment = new AssignmentViewModel
            {
                Id = id,
                Title = id == 1 ? "AI Ethics Case Study" : "Neural Networks Project",
                CourseTitle = id == 1 ? "Introduction to AI" : "Machine Learning Fundamentals",
                DueDate = DateTime.Now.AddDays(id == 1 ? 1 : 3),
                AssignedStudents = id == 1 ? 32 : 28,
                SubmittedCount = id == 1 ? 18 : 12,
                Status = "Upcoming",
                Description = "In this assignment, students will explore the ethical implications of AI in various contexts. They will analyze case studies and provide recommendations for addressing ethical concerns.",
                Instructions = "1. Choose one of the provided case studies\n2. Identify the ethical issues involved\n3. Research relevant ethical frameworks\n4. Analyze the case using these frameworks\n5. Provide recommendations\n6. Submit a 1500-word report",
                PointsPossible = 100,
                Submissions = new List<SubmissionViewModel>
                {
                    new SubmissionViewModel
                    {
                        StudentName = "John Doe",
                        SubmissionDate = DateTime.Now.AddDays(-1),
                        Status = "Submitted",
                        Grade = null
                    },
                    new SubmissionViewModel
                    {
                        StudentName = "Jane Smith",
                        SubmissionDate = DateTime.Now.AddDays(-2),
                        Status = "Submitted",
                        Grade = null
                    },
                    new SubmissionViewModel
                    {
                        StudentName = "Michael Johnson",
                        SubmissionDate = null,
                        Status = "Not Submitted",
                        Grade = null
                    }
                }
            };
            
            return View(assignment);
        }
        
        [HttpGet]
        public IActionResult CreateAssignment()
        {
            ViewData["Title"] = "Create New Assignment";
            
            // In a real application, this would fetch the courses from a database
            // For demo purposes, we're creating a sample list of courses
            ViewBag.Courses = new List<CourseViewModel>
            {
                new CourseViewModel { Id = 1, Title = "Introduction to AI" },
                new CourseViewModel { Id = 2, Title = "Machine Learning Fundamentals" },
                new CourseViewModel { Id = 3, Title = "Deep Learning Applications" },
                new CourseViewModel { Id = 4, Title = "Natural Language Processing" },
                new CourseViewModel { Id = 5, Title = "Computer Vision" }
            };
            
            return View();
        }
        
        [HttpPost]
        public IActionResult CreateAssignment(AssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                // For demo purposes, we'll just redirect to the assignments page
                TempData["SuccessMessage"] = "Assignment created successfully!";
                return RedirectToAction("Assignments");
            }
            
            ViewData["Title"] = "Create New Assignment";
            
            // In a real application, this would fetch the courses from a database
            // For demo purposes, we're creating a sample list of courses
            ViewBag.Courses = new List<CourseViewModel>
            {
                new CourseViewModel { Id = 1, Title = "Introduction to AI" },
                new CourseViewModel { Id = 2, Title = "Machine Learning Fundamentals" },
                new CourseViewModel { Id = 3, Title = "Deep Learning Applications" },
                new CourseViewModel { Id = 4, Title = "Natural Language Processing" },
                new CourseViewModel { Id = 5, Title = "Computer Vision" }
            };
            
            return View(model);
        }
        
        public IActionResult Messages()
        {
            ViewData["Title"] = "Messages";
            return View();
        }
        
        public IActionResult Profile()
        {
            ViewData["Title"] = "Teacher Profile";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
