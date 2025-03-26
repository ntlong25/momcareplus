using MomCarePlus.Domain.Entities;
using MomCarePlus.Domain.Enums;

namespace MomCarePlus.Domain.Interfaces;

public interface IPregnancyAdviceRepository
{
    Task<PregnancyAdvice> GetByIdAsync(Guid id);
    Task<IEnumerable<PregnancyAdvice>> GetByStageAsync(PregnancyStage stage);
    Task<IEnumerable<PregnancyAdvice>> GetByTypeAsync(AdviceType type);
    Task<IEnumerable<PregnancyAdvice>> GetAllAsync();
    Task<PregnancyAdvice> CreateAsync(PregnancyAdvice advice);
    Task<PregnancyAdvice> UpdateAsync(PregnancyAdvice advice);
    Task DeleteAsync(Guid id);
} 