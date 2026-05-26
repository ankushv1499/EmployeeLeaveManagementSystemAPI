using EmployeeLeaveManagementSystemAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagementSystemAPI.DataAcess.Context
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tables
        public DbSet<User> Users { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        // Relationships
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(l => l.User)
                .WithMany(u => u.LeaveRequests)
                .HasForeignKey(l => l.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
