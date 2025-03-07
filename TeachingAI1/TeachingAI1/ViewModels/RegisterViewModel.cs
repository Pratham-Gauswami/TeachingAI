// TeachingAI1/TeachingAI1/ViewModels/RegisterViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace TeachingAI1.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; } // Role can be Student, Teacher, or Admin
    }
}