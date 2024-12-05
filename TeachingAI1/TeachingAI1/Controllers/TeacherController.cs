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
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
