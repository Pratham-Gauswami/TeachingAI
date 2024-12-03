using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeachingAI1.Controllers
{
    public class Admin : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        public IActionResult Settings()
        {
            return View();
        }
    }
}
