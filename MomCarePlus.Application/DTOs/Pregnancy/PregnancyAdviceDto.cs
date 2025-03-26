using MomCarePlus.Domain.Enums;

namespace MomCarePlus.Application.DTOs.Pregnancy;

public class PregnancyAdviceDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public PregnancyStage Stage { get; set; }
    public AdviceType Type { get; set; }
    public bool IsRecommended { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
} 