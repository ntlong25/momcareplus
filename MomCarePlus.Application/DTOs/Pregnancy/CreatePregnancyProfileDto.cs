using System.ComponentModel.DataAnnotations;
using MomCarePlus.Domain.Enums;

namespace MomCarePlus.Application.DTOs.Pregnancy;

public class CreatePregnancyProfileDto
{
    [Required]
    public PregnancyStage Stage { get; set; }

    public DateTime? LastPeriodDate { get; set; }

    public DateTime? ExpectedDeliveryDate { get; set; }

    public int? CurrentWeek { get; set; }

    [Required]
    public bool IsPlanningPregnancy { get; set; }

    public GenderPreference? GenderPreference { get; set; }
} 