using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<LeaveType> LeaveTypes { get; set; }

    public DbSet<LeaveBalance> LeaveBalances { get; set; }

    public DbSet<LeaveRequest> LeaveRequests { get; set; }

    public DbSet<Attendance> Attendances { get; set; }

    public DbSet<Holiday> Holidays { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureRelationships(modelBuilder);

        ConfigureConstraints(modelBuilder);
    }

    private static void ConfigureRelationships(ModelBuilder modelBuilder)
    {
        // User-Manager relationship
    modelBuilder.Entity<User>()
    .HasOne(u => u.Manager)
    .WithMany(m => m.Employees)
    .HasForeignKey(u => u.ManagerId)
    .OnDelete(DeleteBehavior.Restrict);

    // Role relationships
    modelBuilder.Entity<User>()
    .HasOne(u => u.Role)
    .WithMany(r => r.Users)
    .HasForeignKey(u => u.RoleId);

    // Department relationships
    modelBuilder.Entity<User>()
    .HasOne(u => u.Department)
    .WithMany(d => d.Users)
    .HasForeignKey(u => u.DepartmentId);

    //leave balance relationships
    modelBuilder.Entity<LeaveBalance>()
    .HasOne(lb => lb.User)
    .WithMany(u => u.LeaveBalances)
    .HasForeignKey(lb => lb.EmployeeId);

modelBuilder.Entity<LeaveBalance>()
    .HasOne(lb => lb.LeaveType)
    .WithMany(lt => lt.LeaveBalances)
    .HasForeignKey(lb => lb.LeaveTypeId);

    //leave request relationships
modelBuilder.Entity<LeaveRequest>()
    .HasOne(lr => lr.User)
    .WithMany(u => u.LeaveRequests)
    .HasForeignKey(lr => lr.UserId);
    modelBuilder.Entity<LeaveRequest>()
    .HasOne(lr => lr.LeaveType)
    .WithMany(lt => lt.LeaveRequests)
    .HasForeignKey(lr => lr.LeaveTypeId);

// Attendance relationships
    modelBuilder.Entity<Attendance>()
    .HasOne(a => a.User)
    .WithMany(u => u.Attendances)
    .HasForeignKey(a => a.UserId);
    }
    

    private static void ConfigureConstraints(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<User>()
    .HasIndex(u => u.Email)
    .IsUnique();
modelBuilder.Entity<User>()
    .HasIndex(u => u.UserId)
    .IsUnique();
modelBuilder.Entity<Role>()
    .HasIndex(r => r.RoleName)
    .IsUnique();
    modelBuilder.Entity<Department>()
    .HasIndex(d => d.DepartmentName)
    .IsUnique();
    modelBuilder.Entity<LeaveType>()
    .HasIndex(l => l.LeaveTypeName)
    .IsUnique();
    }
}