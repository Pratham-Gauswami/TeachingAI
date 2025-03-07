using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachingAI1.Data;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using TeachingAI1.ViewModels; // For RegisterViewModel and LoginViewModel
using TeachingAI1.Data; // For ApplicationUser

namespace TeachingAI1.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email, Role = model.Role }; // Assuming you have a Role property
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Dashboard", "Account", new { role = model.Role });
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        //For log in - members
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Redirect to the dashboard based on the user's role
                    var user = await _userManager.FindByNameAsync(model.Username);
                    return RedirectToAction("Dashboard", "Account", new { role = user.Role }); // Assuming you have a Role property
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
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
