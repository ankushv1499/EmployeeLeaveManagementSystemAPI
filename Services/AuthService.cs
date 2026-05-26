using BCrypt.Net;
using EmployeeLeaveManagementSystemAPI.Domain.DTOs.Auth;
using EmployeeLeaveManagementSystemAPI.Domain.Entities;
using EmployeeLeaveManagementSystemAPI.Domain.Enum;
using EmployeeLeaveManagementSystemAPI.Domain.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeLeaveManagementSystemAPI.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(
            IUserRepository userRepository,
            IConfiguration configuration

            )
        {
            _userRepository = userRepository;
            _configuration = configuration;

        }

        // Register User
        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            // Check Existing User
            var existingUser =
                await _userRepository.GetByEmailAsync(dto.Email);

            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            // Create User
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                 // Password Hashing
                PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword(dto.Password),
                 Role = dto.Role,

                CreatedDate = DateTime.Now
            };

            // Save User
            await _userRepository.AddUserAsync(user);

            await _userRepository.SaveChangesAsync();

            return "User registered successfully";
        }

        // Login User
        public async Task<AuthResponseDto> LoginAsync(LoginDtos dto)
        {
            // Find User
            var user =
                await _userRepository.GetByEmailAsync(dto.Email);

            if (user == null)
            {
                throw new Exception("Invalid email");
            }

            // Verify Password
            bool isPasswordValid =
                BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    user.PasswordHash);

            if (!isPasswordValid)
            {
                throw new Exception("Invalid password");
            }

            // Generate JWT Token
            var token =
                JwtHelper.GenerateToken(user, _configuration);

            return new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                Role = user.Role.ToString(),
                Expiration = DateTime.Now.AddHours(2)
            };
        }
            private string GenerateToken(User user)
            {
            var claims = new[]

            {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Name, user.Email),
                 new Claim(ClaimTypes.Role, user.Role.ToString())
                
             };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

       
    }
}

