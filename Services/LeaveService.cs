using EmployeeLeaveManagementSystemAPI.Domain.DTOs.Leave;
using EmployeeLeaveManagementSystemAPI.Domain.Entities;
using EmployeeLeaveManagementSystemAPI.Domain.Enum;
using EmployeeLeaveManagementSystemAPI.Domain.Interfaces;

namespace EmployeeLeaveManagementSystemAPI.Services
{
    public class LeaveService
    {
        private readonly ILeaveRepository _leaveRepository;

        public LeaveService(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        // Apply Leave
        public async Task ApplyLeaveAsync(
            LeaveRequestDto dto,
            int userId)
        {
            // Date Validation
            if (dto.StartDate > dto.EndDate)
            {
                throw new Exception(
                    "Start date cannot be greater than end date");
            }

            // Create Leave Entity
            var leave = new LeaveRequest
            {
                UserId = userId,
               
                LeaveType = dto.LeaveType,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Reason = dto.Reason,
                Status = LeaveStatus.Pending,
                CreatedDate = DateTime.Now
            };

            // Save Leave
            await _leaveRepository.AddLeaveAsync(leave);

            await _leaveRepository.SaveChangesAsync();
        }

        // Get My Leaves
        public async Task<List<LeaveResponseDto>>
            GetMyLeavesAsync(int userId)
        {
            var leaves =
                await _leaveRepository.GetMyLeavesAsync(userId);

            return leaves.Select(leave => new LeaveResponseDto
            {
                LeaveId = leave.Id,

                EmployeeName = leave.User.FirstName+ " "+leave.User.LastName,

                LeaveType = leave.LeaveType,

                StartDate = leave.StartDate,

                EndDate = leave.EndDate,

                TotalDays =
                    (leave.EndDate.Date - leave.StartDate.Date)
                    .Days + 1,

                Reason = leave.Reason,

                Status = leave.Status,

                AppliedDate = leave.CreatedDate
            }).ToList();
        }
    }
}
