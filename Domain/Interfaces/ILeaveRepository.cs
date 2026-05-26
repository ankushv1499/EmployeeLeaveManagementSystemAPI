using EmployeeLeaveManagementSystemAPI.Domain.Entities;

namespace EmployeeLeaveManagementSystemAPI.Domain.Interfaces
{
    public interface ILeaveRepository
    {
        // Add Leave
        Task AddLeaveAsync(LeaveRequest leave);

        // Get Employee Leaves
        Task<List<LeaveRequest>> GetMyLeavesAsync(int userId);

        // Get All Leaves
        Task<List<LeaveRequest>> GetAllLeavesAsync();

        // Get Leave By Id
        Task<LeaveRequest> GetByIdAsync(int id);

        // Save Changes
        Task SaveChangesAsync();
    }
}
