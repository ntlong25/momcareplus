using MomCarePlus.Domain.Entities;

namespace MomCarePlus.Domain.Interfaces;

public interface IPregnancyProfileRepository
{
    Task<PregnancyProfile> GetByIdAsync(Guid id);
    Task<PregnancyProfile> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<PregnancyProfile>> GetAllAsync();
    Task<PregnancyProfile> CreateAsync(PregnancyProfile profile);
    Task<PregnancyProfile> UpdateAsync(PregnancyProfile profile);
    Task DeleteAsync(Guid id);
} 