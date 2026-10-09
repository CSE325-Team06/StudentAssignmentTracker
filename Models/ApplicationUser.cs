using Microsoft.AspNetCore.Identity;

namespace StudentAssignmentTracker.Models;

/// <summary>
/// An ASP.NET Core Identity account with student profile and course data.
/// </summary>
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;

    public ICollection<Course> Courses { get; set; } = new List<Course>();

}