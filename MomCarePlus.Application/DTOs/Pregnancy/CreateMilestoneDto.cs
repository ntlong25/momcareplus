using System.ComponentModel.DataAnnotations;

namespace MomCarePlus.Application.DTOs.Pregnancy;

public class CreateMilestoneDto
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    [Required]
    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    public DateTime DueDate { get; set; }
} 