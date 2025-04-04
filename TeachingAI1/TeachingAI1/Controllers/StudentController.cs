using Microsoft.AspNetCore.Mvc;
using TeachingAI1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TeachingAI1.Controllers
{
    public class Student : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        
        public IActionResult Dashboard()
        {
            ViewData["ShowSearch"] = true;
            return View();
        }

        public IActionResult Courses(string filter = null)
        {
            ViewData["Title"] = "My Courses";
            
            // Create a list of courses based on the image
            var courses = new List<CourseDetails>
            {
                new CourseDetails 
                { 
                    Id = 1, 
                    Title = "AI Fundamentals", 
                    Instructor = "Dr. John Smith",
                    Progress = 75,
                    LessonsTotal = 12,
                    LessonsCompleted = 9,
                    TimeLeft = "6h left",
                    ImageUrl = "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                    Status = "In Progress"
                },
                new CourseDetails 
                { 
                    Id = 2, 
                    Title = "Machine Learning Basics", 
                    Instructor = "Dr. Emily Rodriguez",
                    Progress = 45,
                    LessonsTotal = 16,
                    LessonsCompleted = 7,
                    TimeLeft = "12h left",
                    ImageUrl = "https://images.unsplash.com/photo-1555949963-ff9fe0c870eb?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                    Status = "In Progress"
                },
                new CourseDetails 
                { 
                    Id = 3, 
                    Title = "Data Visualization", 
                    Instructor = "Prof. Michael Chen",
                    Progress = 60,
                    LessonsTotal = 10,
                    LessonsCompleted = 6,
                    TimeLeft = "5h left",
                    ImageUrl = "https://images.unsplash.com/photo-1551288049-bebda4e38f71?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                    Status = "In Progress"
                },
                new CourseDetails 
                { 
                    Id = 4, 
                    Title = "Python Programming", 
                    Instructor = "Dr. Sarah Johnson",
                    Progress = 100,
                    LessonsTotal = 20,
                    LessonsCompleted = 20,
                    TimeLeft = "0h left",
                    ImageUrl = "https://images.unsplash.com/photo-1558346490-a72e53ae2d4f?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                    Status = "Completed"
                },
                new CourseDetails 
                { 
                    Id = 5, 
                    Title = "Web Development", 
                    Instructor = "Prof. David Wilson",
                    Progress = 100,
                    LessonsTotal = 15,
                    LessonsCompleted = 15,
                    TimeLeft = "0h left",
                    ImageUrl = "https://images.unsplash.com/photo-1547658719-da2b51169166?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                    Status = "Completed"
                }
            };
            
            // Apply filter if provided
            if (!string.IsNullOrEmpty(filter))
            {
                if (filter.Equals("inprogress", StringComparison.OrdinalIgnoreCase))
                {
                    courses = courses.Where(c => c.Status == "In Progress").ToList();
                }
                else if (filter.Equals("completed", StringComparison.OrdinalIgnoreCase))
                {
                    courses = courses.Where(c => c.Status == "Completed").ToList();
                }
            }
            
            return View(courses);
        }
        
        public IActionResult CourseDetails(int id)
        {
            ViewData["Title"] = "Course Details";
            
            // Create a sample course detail based on the provided id
            var courseDetail = new CourseDetails();
            
            // Match the course details to the corresponding id from the image
            switch (id)
            {
                case 1:
                    courseDetail = new CourseDetails 
                    { 
                        Id = 1, 
                        Title = "AI Fundamentals", 
                        Instructor = "Dr. John Smith",
                        Description = "Learn the core concepts of artificial intelligence, including problem solving, knowledge representation, reasoning, planning, and machine learning.",
                        Progress = 75,
                        LessonsTotal = 12,
                        LessonsCompleted = 9,
                        TimeLeft = "6h left",
                        ImageUrl = "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                        Status = "In Progress",
                        Modules = new List<CourseModule>
                        {
                            new CourseModule 
                            { 
                                Title = "Introduction to AI", 
                                Description = "Understand what AI is and its historical development",
                                LessonCount = 3,
                                CompletedLessons = 3,
                                Status = "Completed"
                            },
                            new CourseModule 
                            { 
                                Title = "Problem Solving and Search", 
                                Description = "Learn about state space representation and search algorithms",
                                LessonCount = 4,
                                CompletedLessons = 4,
                                Status = "Completed"
                            },
                            new CourseModule 
                            { 
                                Title = "Knowledge Representation", 
                                Description = "Explore methods for representing knowledge in AI systems",
                                LessonCount = 3,
                                CompletedLessons = 2,
                                Status = "In Progress"
                            },
                            new CourseModule 
                            { 
                                Title = "Machine Learning Foundations", 
                                Description = "Introduction to key machine learning concepts",
                                LessonCount = 2,
                                CompletedLessons = 0,
                                Status = "Not Started"
                            }
                        }
                    };
                    break;
                case 2:
                    courseDetail = new CourseDetails 
                    { 
                        Id = 2, 
                        Title = "Machine Learning Basics", 
                        Instructor = "Dr. Emily Rodriguez",
                        Description = "A comprehensive introduction to machine learning algorithms, techniques, and methodologies.",
                        Progress = 45,
                        LessonsTotal = 16,
                        LessonsCompleted = 7,
                        TimeLeft = "12h left",
                        ImageUrl = "https://images.unsplash.com/photo-1555949963-ff9fe0c870eb?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                        Status = "In Progress",
                        Modules = new List<CourseModule>
                        {
                            new CourseModule 
                            { 
                                Title = "Introduction to Machine Learning", 
                                Description = "Overview of machine learning and its applications",
                                LessonCount = 3,
                                CompletedLessons = 3,
                                Status = "Completed"
                            },
                            new CourseModule 
                            { 
                                Title = "Supervised Learning", 
                                Description = "Learning with labeled data, including regression and classification",
                                LessonCount = 5,
                                CompletedLessons = 4,
                                Status = "In Progress"
                            },
                            new CourseModule 
                            { 
                                Title = "Unsupervised Learning", 
                                Description = "Learning from unlabeled data, including clustering",
                                LessonCount = 4,
                                CompletedLessons = 0,
                                Status = "Not Started"
                            },
                            new CourseModule 
                            { 
                                Title = "Model Evaluation", 
                                Description = "Techniques for evaluating and improving machine learning models",
                                LessonCount = 4,
                                CompletedLessons = 0,
                                Status = "Not Started"
                            }
                        }
                    };
                    break;
                case 3:
                    courseDetail = new CourseDetails 
                    { 
                        Id = 3, 
                        Title = "Data Visualization", 
                        Instructor = "Prof. Michael Chen",
                        Description = "Learn how to create effective visualizations to communicate insights from data.",
                        Progress = 60,
                        LessonsTotal = 10,
                        LessonsCompleted = 6,
                        TimeLeft = "5h left",
                        ImageUrl = "https://images.unsplash.com/photo-1551288049-bebda4e38f71?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                        Status = "In Progress",
                        Modules = new List<CourseModule>
                        {
                            new CourseModule 
                            { 
                                Title = "Foundations of Data Visualization", 
                                Description = "Basic principles and best practices for data visualization",
                                LessonCount = 2,
                                CompletedLessons = 2,
                                Status = "Completed"
                            },
                            new CourseModule 
                            { 
                                Title = "Visualization Tools and Libraries", 
                                Description = "Overview of popular tools like Matplotlib, Seaborn, and Tableau",
                                LessonCount = 3,
                                CompletedLessons = 3,
                                Status = "Completed"
                            },
                            new CourseModule 
                            { 
                                Title = "Advanced Visualization Techniques", 
                                Description = "Complex visualizations for multidimensional data",
                                LessonCount = 3,
                                CompletedLessons = 1,
                                Status = "In Progress"
                            },
                            new CourseModule 
                            { 
                                Title = "Interactive Visualizations", 
                                Description = "Creating dynamic and interactive data visualizations",
                                LessonCount = 2,
                                CompletedLessons = 0,
                                Status = "Not Started"
                            }
                        }
                    };
                    break;
                case 4:
                    courseDetail = new CourseDetails 
                    { 
                        Id = 4, 
                        Title = "Python Programming", 
                        Instructor = "Dr. Sarah Johnson",
                        Description = "A comprehensive guide to Python programming with applications in data science and AI.",
                        Progress = 100,
                        LessonsTotal = 20,
                        LessonsCompleted = 20,
                        TimeLeft = "0h left",
                        ImageUrl = "https://images.unsplash.com/photo-1558346490-a72e53ae2d4f?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                        Status = "Completed",
                        Modules = new List<CourseModule>
                        {
                            new CourseModule 
                            { 
                                Title = "Python Basics", 
                                Description = "Introduction to Python syntax, data types, and control structures",
                                LessonCount = 5,
                                CompletedLessons = 5,
                                Status = "Completed"
                            },
                            new CourseModule 
                            { 
                                Title = "Data Structures and Algorithms", 
                                Description = "Implementation of key data structures and algorithms in Python",
                                LessonCount = 5,
                                CompletedLessons = 5,
                                Status = "Completed"
                            },
                            new CourseModule 
                            { 
                                Title = "Python for Data Science", 
                                Description = "Using NumPy, Pandas, and other libraries for data analysis",
                                LessonCount = 5,
                                CompletedLessons = 5,
                                Status = "Completed"
                            },
                            new CourseModule 
                            { 
                                Title = "Python for AI", 
                                Description = "Applications of Python in artificial intelligence",
                                LessonCount = 5,
                                CompletedLessons = 5,
                                Status = "Completed"
                            }
                        }
                    };
                    break;
                case 5:
                    courseDetail = new CourseDetails 
                    { 
                        Id = 5, 
                        Title = "Web Development", 
                        Instructor = "Prof. David Wilson",
                        Description = "Learn to build modern, responsive web applications using HTML, CSS, and JavaScript.",
                        Progress = 100,
                        LessonsTotal = 15,
                        LessonsCompleted = 15,
                        TimeLeft = "0h left",
                        ImageUrl = "https://images.unsplash.com/photo-1547658719-da2b51169166?ixlib=rb-1.2.1&auto=format&fit=crop&w=1350&q=80",
                        Status = "Completed",
                        Modules = new List<CourseModule>
                        {
                            new CourseModule 
                            { 
                                Title = "HTML & CSS Fundamentals", 
                                Description = "Building the structure and styling of web pages",
                                LessonCount = 4,
                                CompletedLessons = 4,
                                Status = "Completed"
                            },
                            new CourseModule 
                            { 
                                Title = "JavaScript Essentials", 
                                Description = "Adding interactivity to websites with JavaScript",
                                LessonCount = 4,
                                CompletedLessons = 4,
                                Status = "Completed"
                            },
                            new CourseModule 
                            { 
                                Title = "Responsive Design", 
                                Description = "Creating websites that work on all devices",
                                LessonCount = 3,
                                CompletedLessons = 3,
                                Status = "Completed"
                            },
                            new CourseModule 
                            { 
                                Title = "Web Application Development", 
                                Description = "Building dynamic web applications",
                                LessonCount = 4,
                                CompletedLessons = 4,
                                Status = "Completed"
                            }
                        }
                    };
                    break;
                default:
                    // Default to first course if ID not found
                    return RedirectToAction("CourseDetails", new { id = 1 });
            }
            
            return View(courseDetail);
        }

        public IActionResult Assignments()
        {
            ViewData["Title"] = "My Assignments";
            return View();
        }

        public IActionResult AssignmentSubmission(int id, string assignmentName, string courseName, string dueDate, string worth, bool isOverdue = false)
        {
            ViewData["Title"] = "Assignment Submission";
            ViewData["AssignmentId"] = id;
            ViewData["AssignmentName"] = assignmentName;
            ViewData["CourseName"] = courseName;
            ViewData["DueDate"] = dueDate;
            ViewData["Worth"] = worth;
            ViewData["IsOverdue"] = isOverdue;
            
            return View();
        }

        [HttpPost]
        public IActionResult AssignmentSubmission(int assignmentId, string submissionTitle, string submissionDescription, string submissionText)
        {
            // In a real application, we would save the submission to a database here
            
            // For demo purposes, we'll just redirect with a success message
            TempData["SuccessMessage"] = "Assignment submitted successfully!";
            
            return RedirectToAction("Assignments");
        }

        public IActionResult AssignmentFeedback(int id, string assignmentName, string courseName, string submittedDate, string dueDate, string worth, string grade, string instructorName = "Professor")
        {
            ViewData["Title"] = "Assignment Feedback";
            ViewData["AssignmentId"] = id;
            ViewData["AssignmentName"] = assignmentName;
            ViewData["CourseName"] = courseName;
            ViewData["SubmittedDate"] = submittedDate;
            ViewData["DueDate"] = dueDate;
            ViewData["Worth"] = worth;
            ViewData["Grade"] = grade;
            ViewData["InstructorName"] = instructorName;
            
            return View();
        }

        public IActionResult CourseGradeDetails(int id, string courseName, string courseCode, string credits, string instructor, string finalGrade, string currentGradePercentage, string status, string gradeClass, string gradeColorClass, string gradeTextClass)
        {
            ViewData["Title"] = "Course Grade Details";
            ViewData["CourseName"] = courseName;
            ViewData["CourseCode"] = courseCode;
            ViewData["Credits"] = credits;
            ViewData["Instructor"] = instructor;
            ViewData["FinalGrade"] = finalGrade;
            ViewData["CurrentGradePercentage"] = currentGradePercentage;
            ViewData["Status"] = status;
            ViewData["GradeClass"] = gradeClass;
            ViewData["GradeColorClass"] = gradeColorClass;
            ViewData["GradeTextClass"] = gradeTextClass;
            
            return View();
        }

        public IActionResult Grades()
        {
            ViewData["Title"] = "My Grades";
            return View();
        }

        public IActionResult Certificates()
        {
            ViewData["Title"] = "My Certificates";
            
            // Sample certificates data - in a real app this would come from a database
            var certificates = new List<CertificateViewModel>
            {
                new CertificateViewModel { Title = "AI Fundamentals", IssueDate = DateTime.Now.AddMonths(-3) },
                new CertificateViewModel { Title = "Machine Learning Basics", IssueDate = DateTime.Now.AddMonths(-2) },
                new CertificateViewModel { Title = "Neural Networks and Deep Learning", IssueDate = DateTime.Now.AddMonths(-1) },
                new CertificateViewModel { Title = "Data Science with Python", IssueDate = DateTime.Now.AddDays(-15) },
                new CertificateViewModel { Title = "Natural Language Processing", IssueDate = DateTime.Now.AddDays(-7) }
            };
            
            return View(certificates);
        }

        public IActionResult Calendar()
        {
            ViewData["Title"] = "My Calendar";
            return View();
        }

        public IActionResult Messages()
        {
            ViewData["Title"] = "My Messages";
            return View();
        }

        public IActionResult Profile()
        {
            ViewData["Title"] = "My Profile";
            
            // Sample profile data - in a real app this would come from a database
            var studentProfile = new StudentProfileViewModel
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Bio = "I'm a passionate AI and machine learning enthusiast with a background in computer science. Currently focused on deep learning applications in healthcare.",
                EnrolledCourses = 4,
                AvgGrade = 85,
                LearningHours = 24,
                JoinDate = DateTime.Now.AddMonths(-6),
                ProfileImage = "https://randomuser.me/api/portraits/men/32.jpg",
                Certificates = new List<CertificateViewModel>
                {
                    new CertificateViewModel { Title = "AI Fundamentals", IssueDate = DateTime.Now.AddMonths(-3) },
                    new CertificateViewModel { Title = "Machine Learning Basics", IssueDate = DateTime.Now.AddMonths(-2) }
                }
            };
            
            return View(studentProfile);
        }
        
        public IActionResult EditProfile()
        {
            ViewData["Title"] = "Edit Profile";
            
            // Sample profile data for editing - in a real app this would come from a database
            var studentProfile = new StudentProfileViewModel
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Bio = "I'm a passionate AI and machine learning enthusiast with a background in computer science. Currently focused on deep learning applications in healthcare.",
                Phone = "+1 (555) 123-4567",
                Address = "123 Learning St, Education City, 12345",
                BirthDate = new DateTime(1995, 5, 15),
                Education = "Bachelor of Science in Computer Science",
                Institution = "Tech University",
                Skills = "Python, TensorFlow, Data Analysis, Machine Learning",
                EnrolledCourses = 4,
                AvgGrade = 85,
                LearningHours = 24,
                JoinDate = DateTime.Now.AddMonths(-6),
                ProfileImage = "https://randomuser.me/api/portraits/men/32.jpg"
            };
            
            return View(studentProfile);
        }
        
        [HttpPost]
        public IActionResult EditProfile(StudentProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                // In a real app, save the profile changes to the database
                
                // Add a success message to display on the profile page
                TempData["SuccessMessage"] = "Profile updated successfully!";
                
                // Redirect to the profile page
                return RedirectToAction("Profile");
            }
            
            // If we got this far, something failed; redisplay form
            return View(model);
        }

        public IActionResult HelpCenter()
        {
            ViewData["Title"] = "Help Center";
            return View();
        }

        public IActionResult Settings()
        {
            ViewData["Title"] = "Account Settings";
            
            // In a real application, this would be loaded from a database
            // For demo purposes, we're creating a sample user settings object
            var userSettings = new UserSettings
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                StudentId = "S12345678"
            };
            
            return View(userSettings);
        }
        
        [HttpPost]
        public IActionResult SaveAccountSettings(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                // For demo purposes, we'll just return success
                TempData["SuccessMessage"] = "Account settings updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult ChangePassword(UserSettings model)
        {
            if (string.IsNullOrEmpty(model.CurrentPassword))
            {
                ModelState.AddModelError("CurrentPassword", "Current password is required");
            }
            
            if (string.IsNullOrEmpty(model.NewPassword))
            {
                ModelState.AddModelError("NewPassword", "New password is required");
            }
            
            if (model.NewPassword != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "The new password and confirmation password do not match");
            }
            
            if (ModelState.IsValid)
            {
                // In a real application, this would validate the current password and update to the new one
                // For demo purposes, we'll just return success
                TempData["SuccessMessage"] = "Password changed successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult SavePreferences(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                TempData["SuccessMessage"] = "Preferences updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult SaveNotifications(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                TempData["SuccessMessage"] = "Notification settings updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult SavePrivacySettings(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                TempData["SuccessMessage"] = "Privacy settings updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult SaveAppearance(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                TempData["SuccessMessage"] = "Appearance settings updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult SaveAccessibility(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                TempData["SuccessMessage"] = "Accessibility settings updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult ConnectAccount(string provider)
        {
            // In a real application, this would redirect to the OAuth flow for the provider
            // For demo purposes, we'll just return success
            TempData["SuccessMessage"] = $"Connected to {provider} successfully!";
            return RedirectToAction("Settings");
        }
        
        [HttpPost]
        public IActionResult DisconnectAccount(string provider)
        {
            // In a real application, this would disconnect the account
            // For demo purposes, we'll just return success
            TempData["SuccessMessage"] = $"Disconnected from {provider} successfully!";
            return RedirectToAction("Settings");
        }
        
        [HttpPost]
        public IActionResult DeleteAccount()
        {
            // In a real application, this would delete the user's account after confirmation
            // For demo purposes, we'll just redirect to the login page
            TempData["SuccessMessage"] = "Account deleted successfully!";
            return RedirectToAction("Login", "Account");
        }
    }
}

// Model classes for course details
public class CourseDetails
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Instructor { get; set; }
    public int Progress { get; set; }
    public int TotalLessons { get; set; }
    public int CompletedLessons { get; set; }
    public int HoursLeft { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Rating { get; set; }
    public int TotalStudents { get; set; }
    public DateTime LastAccessed { get; set; }
    public List<CourseModule> Modules { get; set; }
    public string TimeLeft { get; set; }
    public string ImageUrl { get; set; }
    public string Status { get; set; }
    
    // Properties for compatibility 
    public int LessonsTotal { get; set; }
    public int LessonsCompleted { get; set; }
}

public class CourseModule
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int LessonCount { get; set; }
    public int CompletedLessons { get; set; }
    public string Status { get; set; }
}

// Student Profile View Models
public class StudentProfileViewModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime? BirthDate { get; set; }
    public string ProfileImage { get; set; }
    public string Education { get; set; }
    public string Institution { get; set; }
    public string Skills { get; set; }
    
    // Stats
    public int EnrolledCourses { get; set; }
    public int AvgGrade { get; set; }
    public int LearningHours { get; set; }
    public DateTime JoinDate { get; set; }
    
    // Navigation properties
    public List<CertificateViewModel> Certificates { get; set; }
}

public class CertificateViewModel
{
    public string Title { get; set; }
    public DateTime IssueDate { get; set; }
}
