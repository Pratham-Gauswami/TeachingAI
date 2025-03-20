using Microsoft.AspNetCore.Mvc;
using TeachingAI1.Models;
using System;

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
            
            // In a real application, this would be loaded from a database
            // For demo purposes, we're creating a sample user settings object
            var userSettings = new UserSettings
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                StudentId = "S12345678"
            };
            
            return View(userSettings);
        }
        
        [HttpPost]
        public IActionResult SaveAccountSettings(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                // For demo purposes, we'll just return success
                TempData["SuccessMessage"] = "Account settings updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult ChangePassword(UserSettings model)
        {
            if (string.IsNullOrEmpty(model.CurrentPassword))
            {
                ModelState.AddModelError("CurrentPassword", "Current password is required");
            }
            
            if (string.IsNullOrEmpty(model.NewPassword))
            {
                ModelState.AddModelError("NewPassword", "New password is required");
            }
            
            if (model.NewPassword != model.ConfirmPassword)
            {
                ModelState.AddModelError("ConfirmPassword", "The new password and confirmation password do not match");
            }
            
            if (ModelState.IsValid)
            {
                // In a real application, this would validate the current password and update to the new one
                // For demo purposes, we'll just return success
                TempData["SuccessMessage"] = "Password changed successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult SavePreferences(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                TempData["SuccessMessage"] = "Preferences updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult SaveNotifications(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                TempData["SuccessMessage"] = "Notification settings updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult SavePrivacySettings(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                TempData["SuccessMessage"] = "Privacy settings updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult SaveAppearance(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                TempData["SuccessMessage"] = "Appearance settings updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult SaveAccessibility(UserSettings model)
        {
            if (ModelState.IsValid)
            {
                // In a real application, this would save to a database
                TempData["SuccessMessage"] = "Accessibility settings updated successfully!";
                return RedirectToAction("Settings");
            }
            
            ViewData["Title"] = "Account Settings";
            return View("Settings", model);
        }
        
        [HttpPost]
        public IActionResult ConnectAccount(string provider)
        {
            // In a real application, this would redirect to the OAuth flow for the provider
            // For demo purposes, we'll just return success
            TempData["SuccessMessage"] = $"Connected to {provider} successfully!";
            return RedirectToAction("Settings");
        }
        
        [HttpPost]
        public IActionResult DisconnectAccount(string provider)
        {
            // In a real application, this would disconnect the account
            // For demo purposes, we'll just return success
            TempData["SuccessMessage"] = $"Disconnected from {provider} successfully!";
            return RedirectToAction("Settings");
        }
        
        [HttpPost]
        public IActionResult DeleteAccount()
        {
            // In a real application, this would delete the user's account after confirmation
            // For demo purposes, we'll just redirect to the login page
            TempData["SuccessMessage"] = "Account deleted successfully!";
            return RedirectToAction("Login", "Account");
        }
    }
}
