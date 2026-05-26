using EmployeeLeaveManagementSystemAPI.Domain.DTOs.Leave;
using EmployeeLeaveManagementSystemAPI.Domain.Entities;
using EmployeeLeaveManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EmployeeLeaveManagementSystemAPI.Controllers
{
    
    [ApiController]
    [Route("api/leaves")]
    [Authorize(Roles = "Employee")]
    public class LeavesController : ControllerBase
        {
            private readonly LeaveService _leaveService;

       
            public LeavesController(LeaveService leaveService)
            {
                _leaveService = leaveService;
            }

            // POST: api/leaves
            [HttpPost]
            public async Task<IActionResult> ApplyLeave(
                LeaveRequestDto dto)
            {
            // Get Logged-in User Id From JWT Token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("UserId not found in token");

            int userId = int.Parse(userIdClaim);

            
            await _leaveService.ApplyLeaveAsync(dto, userId);

                return Ok(new
                {
                    Message = "Leave applied successfully"
                });
            }

            // GET: api/leaves/my
            [HttpGet("my")]
            public async Task<IActionResult> GetMyLeaves()
            {
           
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
                return Unauthorized("UserId not found in token");

            int userId = int.Parse(userIdClaim);

            var leaves =
                    await _leaveService.GetMyLeavesAsync(userId);

                return Ok(leaves);
            }
        }
    }

