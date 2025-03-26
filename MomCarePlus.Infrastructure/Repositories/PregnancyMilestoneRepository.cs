using Microsoft.EntityFrameworkCore;
using MomCarePlus.Domain.Entities;
using MomCarePlus.Domain.Interfaces;
using MomCarePlus.Infrastructure.Data;

namespace MomCarePlus.Infrastructure.Repositories;

public class PregnancyMilestoneRepository : IPregnancyMilestoneRepository
{
    private readonly ApplicationDbContext _context;

    public PregnancyMilestoneRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PregnancyMilestone> GetByIdAsync(Guid id)
    {
        return await _context.PregnancyMilestones
            .Include(m => m.PregnancyProfile)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<PregnancyMilestone>> GetByProfileIdAsync(Guid profileId)
    {
        return await _context.PregnancyMilestones
            .Include(m => m.PregnancyProfile)
            .Where(m => m.PregnancyProfileId == profileId)
            .ToListAsync();
    }

    public async Task<IEnumerable<PregnancyMilestone>> GetAllAsync()
    {
        return await _context.PregnancyMilestones
            .Include(m => m.PregnancyProfile)
            .ToListAsync();
    }

    public async Task<PregnancyMilestone> CreateAsync(PregnancyMilestone milestone)
    {
        milestone.CreatedAt = DateTime.UtcNow;
        _context.PregnancyMilestones.Add(milestone);
        await _context.SaveChangesAsync();
        return milestone;
    }

    public async Task<PregnancyMilestone> UpdateAsync(PregnancyMilestone milestone)
    {
        milestone.UpdatedAt = DateTime.UtcNow;
        _context.PregnancyMilestones.Update(milestone);
        await _context.SaveChangesAsync();
        return milestone;
    }

    public async Task DeleteAsync(Guid id)
    {
        var milestone = await GetByIdAsync(id);
        if (milestone != null)
        {
            _context.PregnancyMilestones.Remove(milestone);
            await _context.SaveChangesAsync();
        }
    }
} 