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

        public IActionResult StudentFeatures()
        {
            return View();
        }
    }
}
