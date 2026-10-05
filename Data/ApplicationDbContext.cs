using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAssignmentTracker.Models;

namespace StudentAssignmentTracker.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Course> Courses => Set<Course>();

    public DbSet<Assignment> Assignments => Set<Assignment>();

}