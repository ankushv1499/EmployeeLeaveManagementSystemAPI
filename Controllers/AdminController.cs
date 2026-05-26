using EmployeeLeaveManagementSystemAPI.Domain.DTOs.Auth;
using EmployeeLeaveManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeLeaveManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;
        private readonly AuthService _authService;
        public AdminController(AdminService adminService, AuthService authService)
        {
            _adminService = adminService;
            _authService = authService;
        }

        // GET: api/admin/leaves
        [HttpGet("leaves")]
        public async Task<IActionResult> GetAllLeaves()
        {
            var leaves =
                await _adminService.GetAllLeavesAsync();

            return Ok(leaves);
        }

        // PUT: api/admin/leaves/{id}/approve
        [HttpPut("leaves/{id}/approve")]
        public async Task<IActionResult> ApproveLeave(int id)
        {
            await _adminService.ApproveLeaveAsync(id);

            return Ok(new
            {
                Message = "Leave approved successfully"
            });
        }

        // PUT: api/admin/leaves/{id}/reject
        [HttpPut("leaves/{id}/reject")]
        public async Task<IActionResult> RejectLeave(int id)
        {
            await _adminService.RejectLeaveAsync(id);

            return Ok(new
            {
                Message = "Leave rejected successfully"
            });
        }
    }
}
