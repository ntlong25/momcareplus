using MomCarePlus.Domain.Enums;

namespace MomCarePlus.Domain.Entities;

public class PregnancyAdvice
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public PregnancyStage Stage { get; set; }
    public AdviceType Type { get; set; }
    public bool IsRecommended { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public List<PregnancyAdviceCategory> Categories { get; set; } = new();
    public List<PregnancyAdviceTag> Tags { get; set; } = new();
} 