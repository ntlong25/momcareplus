using MomCarePlus.Domain.Enums;

namespace MomCarePlus.Application.DTOs.Pregnancy;

public class PregnancyProfileDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public PregnancyStage Stage { get; set; }
    public DateTime? LastPeriodDate { get; set; }
    public DateTime? ExpectedDeliveryDate { get; set; }
    public int? CurrentWeek { get; set; }
    public bool IsPlanningPregnancy { get; set; }
    public GenderPreference? GenderPreference { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
} 