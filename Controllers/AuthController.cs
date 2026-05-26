using EmployeeLeaveManagementSystemAPI.Domain.DTOs.Auth;
using EmployeeLeaveManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeLeaveManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(
            RegisterDto dto)
        {
            var result =
                await _authService.RegisterAsync(dto);

            return Ok(new
            {
                Message = result
            });
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginDtos dto)
        {
            var response =
                await _authService.LoginAsync(dto);

            return Ok(response);
        }
    }
}
