// TeachingAI1/TeachingAI1/ViewModels/LoginViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace TeachingAI1.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}