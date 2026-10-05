using System.ComponentModel.DataAnnotations;

namespace StudentAssignmentTracker.Models;

public class Course
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string Code { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    public string Semester { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = null!;

    public ICollection<Assignment> Assignments { get; set; }
        = new List<Assignment>();
}