using EmployeeLeaveManagementSystemAPI.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagementSystemAPI.Domain.DTOs.Auth
{
    public class RegisterDto
    {
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}
