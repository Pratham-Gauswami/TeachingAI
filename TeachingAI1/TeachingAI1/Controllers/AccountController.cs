using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachingAI1.Data;

namespace TeachingAI1.Controllers
{
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //For sign in - members
        [HttpPost]
        public IActionResult Register(string username, string password, string role, string email)
        {
            if(ModelState.IsValid)
            {
                var user = new User
                {
                    Name = username,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                    Email = email,
                    Role = role
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }

        //For log in - members
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == username);
           
           if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
           {
                //set session or authentication logic here
                HttpContext.Session.SetString("Role", user.Role);
                return RedirectToAction("Dashboard", user.Role);
           }

           ModelState.AddModelError("", "Invalid login");
           return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Dashboard(string role)
        {
            switch (role)
            {
                case "Student":
                    return RedirectToAction("Index", "Student");
                case "Teacher":
                    return RedirectToAction("Index", "Teacher");
                case "Admin":
                    return RedirectToAction("Index", "Admin");
                default:
                    return RedirectToAction("Login");

            }
        }

  }
}
