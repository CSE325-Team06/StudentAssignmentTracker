using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAssignmentTracker.Models;

namespace StudentAssignmentTracker.Data;

/// <summary>
/// Provides Entity Framework access to identity accounts, courses, and assignments.
/// </summary>
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets the courses owned by application users.
    /// </summary>
    public DbSet<Course> Courses => Set<Course>();

    /// <summary>
    /// Gets assignments associated with courses.
    /// </summary>
    public DbSet<Assignment> Assignments => Set<Assignment>();

}