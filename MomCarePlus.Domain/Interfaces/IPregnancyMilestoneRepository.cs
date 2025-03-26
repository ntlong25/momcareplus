using MomCarePlus.Domain.Entities;

namespace MomCarePlus.Domain.Interfaces;

public interface IPregnancyMilestoneRepository
{
    Task<PregnancyMilestone> GetByIdAsync(Guid id);
    Task<IEnumerable<PregnancyMilestone>> GetByProfileIdAsync(Guid profileId);
    Task<IEnumerable<PregnancyMilestone>> GetAllAsync();
    Task<PregnancyMilestone> CreateAsync(PregnancyMilestone milestone);
    Task<PregnancyMilestone> UpdateAsync(PregnancyMilestone milestone);
    Task DeleteAsync(Guid id);
} 