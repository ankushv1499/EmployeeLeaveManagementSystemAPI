using EmployeeLeaveManagementSystemAPI.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagementSystemAPI.Domain.DTOs.Leave
{
    public class LeaveRequestDto
    {
        [Required]
        public LeaveType LeaveType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [MinLength(5)]
        public string Reason { get; set; }
    }
}
