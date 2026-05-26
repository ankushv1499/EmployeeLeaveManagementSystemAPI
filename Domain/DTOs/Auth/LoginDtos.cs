using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagementSystemAPI.Domain.DTOs.Auth
{
    public class LoginDtos
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
