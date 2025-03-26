using MomCarePlus.Application.DTOs.Pregnancy;
using MomCarePlus.Domain.Enums;

namespace MomCarePlus.Application.Interfaces;

public interface IPregnancyService
{
    Task<PregnancyProfileDto> GetProfileAsync(Guid userId);
    Task<PregnancyProfileDto> CreateProfileAsync(Guid userId, CreatePregnancyProfileDto dto);
    Task<PregnancyProfileDto> UpdateProfileAsync(Guid userId, UpdatePregnancyProfileDto dto);
    Task DeleteProfileAsync(Guid userId);
    Task<IEnumerable<PregnancyAdviceDto>> GetAdviceByStageAsync(PregnancyStage stage);
    Task<IEnumerable<PregnancyAdviceDto>> GetAdviceByTypeAsync(AdviceType type);
    Task<IEnumerable<PregnancyMilestoneDto>> GetMilestonesAsync(Guid profileId);
    Task<PregnancyMilestoneDto> CreateMilestoneAsync(Guid profileId, string title, string description, DateTime dueDate);
    Task<PregnancyMilestoneDto> UpdateMilestoneAsync(Guid milestoneId, bool isCompleted);
    Task DeleteMilestoneAsync(Guid milestoneId);
} 