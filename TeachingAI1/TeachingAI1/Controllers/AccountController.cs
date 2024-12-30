using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == username);
           
           if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
           {
                //set session or authentication logic here
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),          //User's name
                    new Claim(ClaimTypes.Email, user.Email),        //User's email
                    new Claim("UserId", user.Id.ToString()),        //Custome claim for user ID
                    new Claim(ClaimTypes.Role, user.Role)           //User's role
                };

                //Create the identity and principal
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                //Sign the user in with the claims
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                //Redirect based on the user's role
                return RedirectToAction("Dashboard", user.Role);

                // HttpContext.Session.SetString("Role", user.Role);
                // return RedirectToAction("Dashboard", user.Role);
           }

           //If login fails
           ModelState.AddModelError("", "Invalid login");
           return View();
        }

        public async Task<IActionResult> Logout()
        {
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

  }
}
