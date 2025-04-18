using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.API.Models;

public enum ProjectStatus
{
    NotStarted,
    InProgress,
    Completed
}

public class Project
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(500)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public ProjectStatus Status { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
    
    [Required]
    [Range(1, 5)]
    public int Priority { get; set; }
} 