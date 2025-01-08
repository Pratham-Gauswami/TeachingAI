using Microsoft.AspNetCore.Mvc;
using TeachingAI1.Data;
using TeachingAI1.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TeachingAI1.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard()
        {
            // Get current teacher's ID (you'll need to implement authentication)
            var teacherId = GetCurrentTeacherId(); // Implement this based on your auth system

            // Fetch all required data
            ViewBag.TeacherName = await _context.Teachers
                .Where(t => t.Id == teacherId)
                .Select(t => t.Name)
                .FirstOrDefaultAsync();

            ViewBag.ActiveCourses = await _context.Courses
                .CountAsync(c => c.TeacherId == teacherId && c.Status == "Active");

            ViewBag.TotalStudents = await _context.Courses
                .Where(c => c.TeacherId == teacherId)
                .SelectMany(c => c.Students)
                .Distinct()
                .CountAsync();

            ViewBag.PendingAssignments = await _context.Assignments
                .CountAsync(a => a.Course.TeacherId == teacherId && a.Status == "Pending");

            ViewBag.ToGrade = await _context.Assignments
                .CountAsync(a => a.Course.TeacherId == teacherId && a.Status == "To Grade");

            ViewBag.RecentActivities = await _context.Activities
                .Where(a => a.TeacherId == teacherId)
                .OrderByDescending(a => a.Date)
                .Take(5)
                .Select(a => new
                {
                    Description = a.Description,
                    Date = a.Date.ToString("MMM dd, yyyy"),
                    Type = a.Type
                })
                .ToListAsync();

            return View();
        }

        private int GetCurrentTeacherId()
        {
            // Get the claims principal from the User
            var claimsPrincipal = HttpContext.User;
            
            // Fix the comparison
            if (!claimsPrincipal.Identity?.IsAuthenticated ?? true)
            {
                throw new UnauthorizedAccessException("User not authenticated");
            }

            // Getting the teacher id from the claims
            var teacherIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);
            if (teacherIdClaim == null)
            {
                throw new UnauthorizedAccessException("Teacher ID claim not found");
            }

            if (int.TryParse(teacherIdClaim.Value, out int teacherId))
            {
                return teacherId;
            }

            throw new UnauthorizedAccessException("Invalid Teacher ID in claims");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult DebugClaims()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
            return Json(claims);
        }
    }
}
