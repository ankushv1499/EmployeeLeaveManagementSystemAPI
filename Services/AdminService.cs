using EmployeeLeaveManagementSystemAPI.Domain.DTOs.Leave;
using EmployeeLeaveManagementSystemAPI.Domain.Enum;

using EmployeeLeaveManagementSystemAPI.Domain.Interfaces;


namespace EmployeeLeaveManagementSystemAPI.Services
{
    public class AdminService
    {
        private readonly ILeaveRepository _leaveRepository;

        public AdminService(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        // Get All Leaves
        public async Task<List<LeaveResponseDto>>
            GetAllLeavesAsync()
        {
            var leaves =
                await _leaveRepository.GetAllLeavesAsync();

            return leaves.Select(leave => new LeaveResponseDto
            {
                LeaveId = leave.Id,

                EmployeeName =
                    $"{leave.User.FirstName} {leave.User.LastName}",

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

        // Approve Leave
        public async Task ApproveLeaveAsync(int id)
        {
            var leave =
                await _leaveRepository.GetByIdAsync(id);

            if (leave == null)
            {
                throw new KeyNotFoundException("Leave request not found");
            }

            leave.Status = LeaveStatus.Approved;

            await _leaveRepository.SaveChangesAsync();
        }

        // Reject Leave
        public async Task RejectLeaveAsync(int id)
        {
            var leave =
                await _leaveRepository.GetByIdAsync(id);

            if (leave == null)
            {
                throw new KeyNotFoundException("Leave request not found");
            }

            leave.Status = LeaveStatus.Rejected;

            await _leaveRepository.SaveChangesAsync();
        }
    }
}
