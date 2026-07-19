using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;

namespace HRDesk.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "We need to know your name")]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password) , ErrorMessage = "Password & Confirm Password doesnot match!!")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
