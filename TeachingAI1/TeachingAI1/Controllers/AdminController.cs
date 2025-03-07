using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeachingAI1.Data;
using TeachingAI1.Models;
using System.Linq;

namespace TeachingAI1.Controllers
{
    public class Admin : Controller
    {
        private readonly ApplicationDbContext _context;

        public Admin(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        // public ActionResult Index1()
        // {
        //     return View();
        // }
        
        [Authorize(Roles = "Admin")]
        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            ViewData["ShowSearch"] = true;
            return View();
        }

        public IActionResult Index1(string search)
        {
            var users = _context.Users
            .Select(user => new User
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                IsLoggedIn = user.IsLoggedIn,
                LastActivity = user.LastActivity
            })
            .ToList();
            Console.WriteLine($"Number of users: {users.Count}");
            return View("Index1", users); //Pass data to the index1 view
        }
    }
}
