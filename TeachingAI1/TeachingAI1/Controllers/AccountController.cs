using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachingAI1.Data;
using TeachingAI1.Models;

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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Verify login credentials
            var teacher = await _context.Teachers
                .FirstOrDefaultAsync(t => t.Email == model.Email);

            if (teacher == null || !VerifyPassword(model.Password, teacher.PasswordHash))
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

            // Create claims for the teacher
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, teacher.Id.ToString()),
                new Claim(ClaimTypes.Name, teacher.Name),
                new Claim(ClaimTypes.Email, teacher.Email),
                new Claim(ClaimTypes.Role, "Teacher")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToAction("Dashboard", "Teacher");
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Implement your password verification logic here
            // Example using BCrypt:
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // var user = await _userManager.GetUserAsync(User); 
            var UserId = User.FindFirst("UserId")?.Value; //get the logged in user

            if(!string.IsNullOrEmpty(UserId))
            {
                //Fetching the user from the databse
                var user  = await _context.Users.FindAsync(int.Parse(UserId));
                //Logic for checking if anyone has logged in or not
                if(user != null){
                    //Updating user's loggedin status
                    user.IsLoggedIn = false;
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
            }
            //Sign out the user and clear the authentication cookie
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Dashboard(string role)
        {
            switch (role)
            {
                case "Student":
                    return RedirectToAction("Index1", "Student");
                case "Teacher":
                    return RedirectToAction("Index1", "Teacher");
                case "Admin":
                    return RedirectToAction("Index1", "Admin");
                default:
                    return RedirectToAction("Login");

            }
        }

        public IActionResult Profile()
        {
            var username = User.FindFirst(ClaimTypes.Name)?. Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var userId = User.FindFirst("UserId")?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            return View();
        }

  }
}
