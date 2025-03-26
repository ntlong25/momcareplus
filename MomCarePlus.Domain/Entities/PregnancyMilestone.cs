using MomCarePlus.Domain.Enums;

namespace MomCarePlus.Domain.Entities;

public class PregnancyMilestone
{
    public Guid Id { get; set; }
    public Guid PregnancyProfileId { get; set; }
    public PregnancyProfile PregnancyProfile { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
} 