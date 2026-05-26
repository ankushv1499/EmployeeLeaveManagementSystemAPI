using EmployeeLeaveManagementSystemAPI.Domain.Enum;

namespace EmployeeLeaveManagementSystemAPI.Domain.DTOs.Leave
{
    public class LeaveResponseDto
    {
        public int LeaveId { get; set; }

        public string EmployeeName { get; set; }

        public LeaveType LeaveType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TotalDays { get; set; }

        public string Reason { get; set; }

        public LeaveStatus Status { get; set; }

        public DateTime AppliedDate { get; set; }
    }
}
