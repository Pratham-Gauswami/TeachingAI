using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult TeacherFeatures()
        {
            return View();
        }
    }
}
