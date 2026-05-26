using EmployeeLeaveManagementSystemAPI.Domain.Enum;

namespace EmployeeLeaveManagementSystemAPI.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public Role Role { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
