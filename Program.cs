using EmployeeLeaveManagementSystemAPI.DataAcess.Context;
using EmployeeLeaveManagementSystemAPI.DataAcess.Repositories;
using EmployeeLeaveManagementSystemAPI.Domain.Interfaces;
using EmployeeLeaveManagementSystemAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. ADD CONTROLLERS

builder.Services.AddControllers();


/// 2. SWAGGER (API DOCUMENTATION)

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//  3. DATABASE CONNECTION (SQL SERVER + EF CORE)

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


//  4. DEPENDENCY INJECTION (REPOSITORIES)

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILeaveRepository, LeaveRepository>();


// 5. DEPENDENCY INJECTION (SERVICES)
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<LeaveService>();
builder.Services.AddScoped<AdminService>();


//6. JWT AUTHENTICATION CONFIGURATION
var jwt = builder.Configuration.GetSection("Jwt");
var key = jwt["Key"];

if (string.IsNullOrEmpty(key))
{
    throw new Exception("JWT Key is missing in appsettings.json");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwt["Issuer"],
        ValidAudience = jwt["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key)
        ),
       
        NameClaimType = ClaimTypes.NameIdentifier,
        RoleClaimType = ClaimTypes.Role
    };
});


//  AUTHORIZATION (ROLE BASED ACCESS)
builder.Services.AddAuthorization();


//  BUILD APPLICATION
var app = builder.Build();


// Swagger only in development mode

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseRouting();

//Middleware
app.UseMiddleware<ExceptionMiddleware>();


//  Authenticate user (check token)
app.UseAuthentication();

//  Check permissions (roles like Admin/Employee)
app.UseAuthorization();


// 99. MAP CONTROLLERS (API ROUTES)

app.MapControllers();


app.Run();