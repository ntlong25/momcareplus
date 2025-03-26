using Microsoft.EntityFrameworkCore;
using MomCarePlus.Domain.Entities;
using MomCarePlus.Domain.Interfaces;
using MomCarePlus.Infrastructure.Data;

namespace MomCarePlus.Infrastructure.Repositories;

public class PregnancyProfileRepository : IPregnancyProfileRepository
{
    private readonly ApplicationDbContext _context;

    public PregnancyProfileRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PregnancyProfile> GetByIdAsync(Guid id)
    {
        return await _context.PregnancyProfiles
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<PregnancyProfile> GetByUserIdAsync(Guid userId)
    {
        return await _context.PregnancyProfiles
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.UserId == userId);
    }

    public async Task<IEnumerable<PregnancyProfile>> GetAllAsync()
    {
        return await _context.PregnancyProfiles
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task<PregnancyProfile> CreateAsync(PregnancyProfile profile)
    {
        _context.PregnancyProfiles.Add(profile);
        await _context.SaveChangesAsync();
        return profile;
    }

    public async Task<PregnancyProfile> UpdateAsync(PregnancyProfile profile)
    {
        profile.UpdatedAt = DateTime.UtcNow;
        _context.PregnancyProfiles.Update(profile);
        await _context.SaveChangesAsync();
        return profile;
    }

    public async Task DeleteAsync(Guid id)
    {
        var profile = await GetByIdAsync(id);
        if (profile != null)
        {
            _context.PregnancyProfiles.Remove(profile);
            await _context.SaveChangesAsync();
        }
    }
} 