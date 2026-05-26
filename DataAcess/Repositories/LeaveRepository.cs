using EmployeeLeaveManagementSystemAPI.DataAcess.Context;
using EmployeeLeaveManagementSystemAPI.Domain.Entities;
using EmployeeLeaveManagementSystemAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagementSystemAPI.DataAcess.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor Injection
        public LeaveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add Leave
        public async Task AddLeaveAsync(LeaveRequest leave)
        {
            await _context.LeaveRequests.AddAsync(leave);
        }

        // Get Employee Leaves
        public async Task<List<LeaveRequest>>
            GetMyLeavesAsync(int userId)
        {
            return await _context.LeaveRequests
                .Include(x => x.User)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        // Get All Leaves
        public async Task<List<LeaveRequest>>
            GetAllLeavesAsync()
        {
            return await _context.LeaveRequests
                .Include(x => x.User)
                .ToListAsync();
        }

        // Get Leave By Id
        public async Task<LeaveRequest>
            GetByIdAsync(int id)
        {
            return await _context.LeaveRequests
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Save Changes
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
