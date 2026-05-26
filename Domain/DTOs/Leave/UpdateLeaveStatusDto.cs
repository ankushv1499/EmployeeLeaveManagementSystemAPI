using EmployeeLeaveManagementSystemAPI.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagementSystemAPI.Domain.DTOs.Leave
{
    public class UpdateLeaveStatusDto
    {
        [Required]
        public LeaveStatus Status { get; set; }
    }
}
