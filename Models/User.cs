using System.ComponentModel.DataAnnotations;
using System;

namespace HRDesk.Models
{

    public class User
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = "User";

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public bool EmailConfirmed { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public int FailedLoginAttempts { get; set; } = 0;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLoginAt { get; set; }
    }
}
