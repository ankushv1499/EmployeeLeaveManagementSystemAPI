using EmployeeLeaveManagementSystemAPI.Domain.Enum;

namespace EmployeeLeaveManagementSystemAPI.Domain.Entities
{
    public class LeaveRequest
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public LeaveType LeaveType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Reason { get; set; }

        public LeaveStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public User User { get; set; }
    }
}
