using AutoMapper;
using MomCarePlus.Application.DTOs.Pregnancy;
using MomCarePlus.Application.Interfaces;
using MomCarePlus.Domain.Entities;
using MomCarePlus.Domain.Enums;
using MomCarePlus.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MomCarePlus.Application.Services;

public class PregnancyService : IPregnancyService
{
    private readonly IPregnancyProfileRepository _profileRepository;
    private readonly IPregnancyAdviceRepository _adviceRepository;
    private readonly IPregnancyMilestoneRepository _milestoneRepository;
    private readonly IMapper _mapper;

    public PregnancyService(
        IPregnancyProfileRepository profileRepository,
        IPregnancyAdviceRepository adviceRepository,
        IPregnancyMilestoneRepository milestoneRepository,
        IMapper mapper)
    {
        _profileRepository = profileRepository;
        _adviceRepository = adviceRepository;
        _milestoneRepository = milestoneRepository;
        _mapper = mapper;
    }

    public async Task<PregnancyProfileDto> GetProfileAsync(Guid userId)
    {
        var profile = await _profileRepository.GetByUserIdAsync(userId);
        if (profile == null)
        {
            throw new ValidationException("Pregnancy profile not found");
        }

        return _mapper.Map<PregnancyProfileDto>(profile);
    }

    public async Task<PregnancyProfileDto> CreateProfileAsync(Guid userId, CreatePregnancyProfileDto dto)
    {
        var existingProfile = await _profileRepository.GetByUserIdAsync(userId);
        if (existingProfile != null)
        {
            throw new ValidationException("User already has a pregnancy profile");
        }

        var profile = _mapper.Map<PregnancyProfile>(dto);
        profile.UserId = userId;
        profile.CreatedAt = DateTime.UtcNow;

        var createdProfile = await _profileRepository.CreateAsync(profile);
        return _mapper.Map<PregnancyProfileDto>(createdProfile);
    }

    public async Task<PregnancyProfileDto> UpdateProfileAsync(Guid userId, UpdatePregnancyProfileDto dto)
    {
        var profile = await _profileRepository.GetByUserIdAsync(userId);
        if (profile == null)
        {
            throw new ValidationException("Pregnancy profile not found");
        }

        _mapper.Map(dto, profile);
        profile.UpdatedAt = DateTime.UtcNow;

        var updatedProfile = await _profileRepository.UpdateAsync(profile);
        return _mapper.Map<PregnancyProfileDto>(updatedProfile);
    }

    public async Task DeleteProfileAsync(Guid userId)
    {
        var profile = await _profileRepository.GetByUserIdAsync(userId);
        if (profile == null)
        {
            throw new ValidationException("Pregnancy profile not found");
        }

        await _profileRepository.DeleteAsync(profile.Id);
    }

    public async Task<IEnumerable<PregnancyAdviceDto>> GetAdviceByStageAsync(PregnancyStage stage)
    {
        var advice = await _adviceRepository.GetByStageAsync(stage);
        return _mapper.Map<IEnumerable<PregnancyAdviceDto>>(advice);
    }

    public async Task<IEnumerable<PregnancyAdviceDto>> GetAdviceByTypeAsync(AdviceType type)
    {
        var advice = await _adviceRepository.GetByTypeAsync(type);
        return _mapper.Map<IEnumerable<PregnancyAdviceDto>>(advice);
    }

    public async Task<IEnumerable<PregnancyMilestoneDto>> GetMilestonesAsync(Guid profileId)
    {
        var milestones = await _milestoneRepository.GetByProfileIdAsync(profileId);
        return _mapper.Map<IEnumerable<PregnancyMilestoneDto>>(milestones);
    }

    public async Task<PregnancyMilestoneDto> CreateMilestoneAsync(Guid profileId, string title, string description, DateTime dueDate)
    {
        var profile = await _profileRepository.GetByIdAsync(profileId);
        if (profile == null)
        {
            throw new ValidationException("Pregnancy profile not found");
        }

        var milestone = new PregnancyMilestone
        {
            PregnancyProfileId = profileId,
            Title = title,
            Description = description,
            DueDate = dueDate,
            IsCompleted = false,
            CreatedAt = DateTime.UtcNow
        };

        var createdMilestone = await _milestoneRepository.CreateAsync(milestone);
        return _mapper.Map<PregnancyMilestoneDto>(createdMilestone);
    }

    public async Task<PregnancyMilestoneDto> UpdateMilestoneAsync(Guid milestoneId, bool isCompleted)
    {
        var milestone = await _milestoneRepository.GetByIdAsync(milestoneId);
        if (milestone == null)
        {
            throw new ValidationException("Milestone not found");
        }

        milestone.IsCompleted = isCompleted;
        milestone.CompletedAt = isCompleted ? DateTime.UtcNow : null;
        milestone.UpdatedAt = DateTime.UtcNow;

        var updatedMilestone = await _milestoneRepository.UpdateAsync(milestone);
        return _mapper.Map<PregnancyMilestoneDto>(updatedMilestone);
    }

    public async Task DeleteMilestoneAsync(Guid milestoneId)
    {
        var milestone = await _milestoneRepository.GetByIdAsync(milestoneId);
        if (milestone == null)
        {
            throw new ValidationException("Milestone not found");
        }

        await _milestoneRepository.DeleteAsync(milestoneId);
    }
} 