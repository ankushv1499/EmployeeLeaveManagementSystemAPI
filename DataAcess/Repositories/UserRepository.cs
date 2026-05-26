using EmployeeLeaveManagementSystemAPI.DataAcess.Context;
using EmployeeLeaveManagementSystemAPI.Domain.Entities;
using EmployeeLeaveManagementSystemAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagementSystemAPI.DataAcess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor Injection
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get User By Email
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        // Add User
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        // Save Changes
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
