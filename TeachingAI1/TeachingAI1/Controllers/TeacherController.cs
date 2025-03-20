using Microsoft.AspNetCore.Mvc;
using TeachingAI1.Models;
using TeachingAI1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeachingAI1.ViewModels;

namespace TeachingAI1.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            ViewData["ShowSearch"] = true;
            ViewData["Title"] = "Teacher Dashboard";
            
            // Get real data from the database
            ViewBag.ActiveCourses = _context.Courses.Count(c => c.Status == "Active");
            ViewBag.TotalStudents = _context.Users.Count();
            ViewBag.PendingAssignments = 12; // This would need a proper assignments table
            ViewBag.NewMessages = 24; // This would need a proper messages table
            
            return View();
        }
        
        public IActionResult Courses()
        {
            ViewData["Title"] = "My Courses";
            
            // Get the teacher's ID (in a real app this would come from authentication)
            int teacherId = 1; // Placeholder
            
            // Get courses from the database - convert from Course to CourseViewModel
            var courses = _context.Courses
                .Where(c => c.TeacherId == teacherId)
                .Select(c => new ViewModels.CourseViewModel
                {
                    Id = c.Id,
                    Title = c.Name,
                    Description = "No description available", // Default value since Description doesn't exist in DB
                    EnrolledStudents = 32, // This would need a proper enrollment table
                    Duration = "12 Weeks", // This would need to be calculated or stored
                    Attendance = 87, // This would need to be calculated
                    Completion = 92, // This would need to be calculated
                    Rating = 4.8, // This would need to be calculated
                    Status = c.Status,
                    StartDate = DateTime.Now.AddDays(-30), // Default value since CreatedOn doesn't exist in DB
                    EndDate = DateTime.Now.AddDays(60) // This would need to be stored
                })
                .ToList();
            
            // If no courses are found, use sample data for demo purposes
            if (!courses.Any())
            {
                courses = GetSampleCourses();
            }
            
            return View(courses);
        }
        
        private List<ViewModels.CourseViewModel> GetSampleCourses()
        {
            // Sample data for demonstration purposes
            return new List<ViewModels.CourseViewModel>
            {
                new ViewModels.CourseViewModel
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
                // Additional sample courses...
            };
        }
        
        public IActionResult CourseDetails(int id)
        {
            ViewData["Title"] = "Course Details";
            
            // Get the course from the database
            var dbCourse = _context.Courses.FirstOrDefault(c => c.Id == id);
            
            // If the course is found, map it to a CourseViewModel
            if (dbCourse != null)
            {
                var course = new ViewModels.CourseViewModel
                {
                    Id = dbCourse.Id,
                    Title = dbCourse.Name,
                    Description = "No description available", // Default value since Description doesn't exist in DB
                    EnrolledStudents = 32, // This would need enrollment data
                    Duration = "12 Weeks", // This would need duration data
                    Attendance = 87, // This would need attendance data
                    Completion = 92, // This would need progress data
                    Rating = 4.8, // This would need rating data
                    Status = dbCourse.Status,
                    StartDate = DateTime.Now.AddDays(-30), // Default value since CreatedOn doesn't exist in DB
                    EndDate = DateTime.Now.AddDays(60), // This would need end date data
                    Syllabus = "Week 1: Introduction to AI\nWeek 2: Problem Solving\n..." // This would need syllabus data
                };
                return View(course);
            }
            
            // If not found, use sample data for demo purposes
            var sampleCourse = new ViewModels.CourseViewModel
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
            
            return View(sampleCourse);
        }
        
        [HttpGet]
        public IActionResult CreateCourse()
        {
            ViewData["Title"] = "Create New Course";
            
            // Initialize model with today's date and future end date
            var model = new ViewModels.CourseViewModel
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddMonths(3),
                Status = "Active"
            };
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCourse(ViewModels.CourseViewModel model)
        {
            // Remove validation errors for fields that we don't need
            ModelState.Remove("Students");
            ModelState.Remove("Assignments");
            ModelState.Remove("Grade");
            
            // Ensure Name and Title are synchronized (since we use Title in the view but Name in the database)
            if (!string.IsNullOrEmpty(model.Title) && string.IsNullOrEmpty(model.Name))
            {
                model.Name = model.Title;
            }
            else if (!string.IsNullOrEmpty(model.Name) && string.IsNullOrEmpty(model.Title))
            {
                model.Title = model.Name;
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    // Get the current user's ID (this is a placeholder)
                    var teacherId = 1; // In a real application, get the actual ID from the identity

                    // Map CourseViewModel to Course (only saving properties that exist in the database)
                    var course = new Course
                    {
                        Name = model.Title, // Use Title from the model
                        Status = model.Status,
                        TeacherId = teacherId
                        // Description and CreatedOn are not included since they don't exist in the database
                    };

                    _context.Courses.Add(course);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Course created successfully!";
                    return RedirectToAction(nameof(Courses));
                }
                catch (Exception ex)
                {
                    // Log the error
                    // _logger.LogError(ex, "Error creating course");
                    
                    ModelState.AddModelError("", "An error occurred while saving the course. Please try again.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        
        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            ViewData["Title"] = "Edit Course";
            
            // Get the course from the database
            var dbCourse = _context.Courses.FirstOrDefault(c => c.Id == id);
            
            // If the course is found, map it to a CourseViewModel
            if (dbCourse != null)
            {
                var course = new ViewModels.CourseViewModel
                {
                    Id = dbCourse.Id,
                    Title = dbCourse.Name,
                    Description = "No description available", // Default value since Description doesn't exist in DB
                    Status = dbCourse.Status,
                    StartDate = DateTime.Now.AddDays(-30), // Default value since CreatedOn doesn't exist in DB
                    EndDate = DateTime.Now.AddDays(60), // This would need end date data
                    // Map other properties as needed
                };
                return View(course);
            }
            
            // If not found, use sample data for demo purposes
            var sampleCourse = new ViewModels.CourseViewModel
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
            
            return View(sampleCourse);
        }
        
        [HttpPost]
        public async Task<IActionResult> EditCourse(ViewModels.CourseViewModel model)
        {
            // Remove validation errors for Students, Assignments, and Grade
            ModelState.Remove("Students");
            ModelState.Remove("Assignments");
            ModelState.Remove("Grade");
            
            if (ModelState.IsValid)
            {
                try
                {
                    // Get the course from the database
                    var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == model.Id);
                    
                    if (course != null)
                    {
                        // Update properties - only those that exist in the database
                        course.Name = model.Title;
                        course.Status = model.Status;
                        // Not updating Description or CreatedOn since they don't exist in DB
                        
                        // Save changes
                        await _context.SaveChangesAsync();
                        
                        // Success message and redirect
                        TempData["SuccessMessage"] = "Course updated successfully!";
                        return RedirectToAction("CourseDetails", new { id = model.Id });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Course not found.");
                    }
                }
                catch (Exception ex)
                {
                    // Log the error (in a real app)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                    // Log error: Console.WriteLine($"Error: {ex.Message}, StackTrace: {ex.StackTrace}");
                }
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
                Courses = new List<ViewModels.CourseViewModel>
                {
                    new ViewModels.CourseViewModel
                    {
                        Id = 1,
                        Title = "Introduction to AI",
                        Progress = 90,
                        Grade = "A-"
                    },
                    new ViewModels.CourseViewModel
                    {
                        Id = 2,
                        Title = "Machine Learning Fundamentals",
                        Progress = 85,
                        Grade = "B+"
                    },
                    new ViewModels.CourseViewModel
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
            ViewBag.Courses = new List<ViewModels.CourseViewModel>
            {
                new ViewModels.CourseViewModel { Id = 1, Title = "Introduction to AI" },
                new ViewModels.CourseViewModel { Id = 2, Title = "Machine Learning Fundamentals" },
                new ViewModels.CourseViewModel { Id = 3, Title = "Deep Learning Applications" },
                new ViewModels.CourseViewModel { Id = 4, Title = "Natural Language Processing" },
                new ViewModels.CourseViewModel { Id = 5, Title = "Computer Vision" }
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
            ViewBag.Courses = new List<ViewModels.CourseViewModel>
            {
                new ViewModels.CourseViewModel { Id = 1, Title = "Introduction to AI" },
                new ViewModels.CourseViewModel { Id = 2, Title = "Machine Learning Fundamentals" },
                new ViewModels.CourseViewModel { Id = 3, Title = "Deep Learning Applications" },
                new ViewModels.CourseViewModel { Id = 4, Title = "Natural Language Processing" },
                new ViewModels.CourseViewModel { Id = 5, Title = "Computer Vision" }
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
