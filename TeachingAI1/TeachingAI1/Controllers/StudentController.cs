using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Courses()
        {
            ViewData["Title"] = "My Courses";
            return View();
        }

        public IActionResult Assignments()
        {
            ViewData["Title"] = "My Assignments";
            return View();
        }

        public IActionResult Grades()
        {
            ViewData["Title"] = "My Grades";
            return View();
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
            return View();
        }

        public IActionResult HelpCenter()
        {
            ViewData["Title"] = "Help Center";
            return View();
        }

        public IActionResult Settings()
        {
            ViewData["Title"] = "Account Settings";
            return View();
        }
    }
}
