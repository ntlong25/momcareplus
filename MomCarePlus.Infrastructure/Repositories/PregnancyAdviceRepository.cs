using Microsoft.EntityFrameworkCore;
using MomCarePlus.Domain.Entities;
using MomCarePlus.Domain.Enums;
using MomCarePlus.Domain.Interfaces;
using MomCarePlus.Infrastructure.Data;

namespace MomCarePlus.Infrastructure.Repositories;

public class PregnancyAdviceRepository : IPregnancyAdviceRepository
{
    private readonly ApplicationDbContext _context;

    public PregnancyAdviceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PregnancyAdvice> GetByIdAsync(Guid id)
    {
        return await _context.PregnancyAdvices.FindAsync(id);
    }

    public async Task<IEnumerable<PregnancyAdvice>> GetByStageAsync(PregnancyStage stage)
    {
        return await _context.PregnancyAdvices
            .Where(a => a.Stage == stage)
            .ToListAsync();
    }

    public async Task<IEnumerable<PregnancyAdvice>> GetByTypeAsync(AdviceType type)
    {
        return await _context.PregnancyAdvices
            .Where(a => a.Type == type)
            .ToListAsync();
    }

    public async Task<IEnumerable<PregnancyAdvice>> GetAllAsync()
    {
        return await _context.PregnancyAdvices.ToListAsync();
    }

    public async Task<PregnancyAdvice> CreateAsync(PregnancyAdvice advice)
    {
        advice.CreatedAt = DateTime.UtcNow;
        _context.PregnancyAdvices.Add(advice);
        await _context.SaveChangesAsync();
        return advice;
    }

    public async Task<PregnancyAdvice> UpdateAsync(PregnancyAdvice advice)
    {
        advice.UpdatedAt = DateTime.UtcNow;
        _context.PregnancyAdvices.Update(advice);
        await _context.SaveChangesAsync();
        return advice;
    }

    public async Task DeleteAsync(Guid id)
    {
        var advice = await GetByIdAsync(id);
        if (advice != null)
        {
            _context.PregnancyAdvices.Remove(advice);
            await _context.SaveChangesAsync();
        }
    }
} 