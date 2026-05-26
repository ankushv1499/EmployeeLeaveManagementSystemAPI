using EmployeeLeaveManagementSystemAPI.Domain.Entities;

namespace EmployeeLeaveManagementSystemAPI.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);

        Task AddUserAsync(User user);

        Task SaveChangesAsync();
    }
}
