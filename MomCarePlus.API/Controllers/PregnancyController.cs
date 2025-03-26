using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MomCarePlus.Application.DTOs.Pregnancy;
using MomCarePlus.Application.Interfaces;
using MomCarePlus.Domain.Enums;
using System.Security.Claims;
using FluentValidation;

namespace MomCarePlus.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PregnancyController : ControllerBase
{
    private readonly IPregnancyService _pregnancyService;

    public PregnancyController(IPregnancyService pregnancyService)
    {
        _pregnancyService = pregnancyService;
    }

    private Guid GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim == null)
        {
            throw new UnauthorizedAccessException("User ID not found in token");
        }
        return Guid.Parse(userIdClaim.Value);
    }

    #region Profile Endpoints
    [HttpGet("profile")]
    public async Task<ActionResult<PregnancyProfileDto>> GetProfile()
    {
        try
        {
            var userId = GetCurrentUserId();
            var profile = await _pregnancyService.GetProfileAsync(userId);
            return Ok(profile);
        }
        catch (ValidationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("profile")]
    public async Task<ActionResult<PregnancyProfileDto>> CreateProfile(CreatePregnancyProfileDto dto)
    {
        try
        {
            var userId = GetCurrentUserId();
            var profile = await _pregnancyService.CreateProfileAsync(userId, dto);
            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("profile")]
    public async Task<ActionResult<PregnancyProfileDto>> UpdateProfile(UpdatePregnancyProfileDto dto)
    {
        try
        {
            var userId = GetCurrentUserId();
            var profile = await _pregnancyService.UpdateProfileAsync(userId, dto);
            return Ok(profile);
        }
        catch (ValidationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("profile")]
    public async Task<IActionResult> DeleteProfile()
    {
        try
        {
            var userId = GetCurrentUserId();
            await _pregnancyService.DeleteProfileAsync(userId);
            return NoContent();
        }
        catch (ValidationException ex)
        {
            return NotFound(ex.Message);
        }
    }
    #endregion

    #region Advice Endpoints
    [HttpGet("advice/stage/{stage}")]
    public async Task<ActionResult<IEnumerable<PregnancyAdviceDto>>> GetAdviceByStage(PregnancyStage stage)
    {
        var advice = await _pregnancyService.GetAdviceByStageAsync(stage);
        return Ok(advice);
    }

    [HttpGet("advice/type/{type}")]
    public async Task<ActionResult<IEnumerable<PregnancyAdviceDto>>> GetAdviceByType(AdviceType type)
    {
        var advice = await _pregnancyService.GetAdviceByTypeAsync(type);
        return Ok(advice);
    }
    #endregion

    #region Milestone Endpoints
    [HttpGet("milestones")]
    public async Task<ActionResult<IEnumerable<PregnancyMilestoneDto>>> GetMilestones()
    {
        try
        {
            var userId = GetCurrentUserId();
            var profile = await _pregnancyService.GetProfileAsync(userId);
            var milestones = await _pregnancyService.GetMilestonesAsync(profile.Id);
            return Ok(milestones);
        }
        catch (ValidationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost("milestones")]
    public async Task<ActionResult<PregnancyMilestoneDto>> CreateMilestone([FromBody] CreateMilestoneDto dto)
    {
        try
        {
            var userId = GetCurrentUserId();
            var profile = await _pregnancyService.GetProfileAsync(userId);
            var milestone = await _pregnancyService.CreateMilestoneAsync(
                profile.Id,
                dto.Title,
                dto.Description,
                dto.DueDate);
            return CreatedAtAction(nameof(GetMilestones), new { id = milestone.Id }, milestone);
        }
        catch (ValidationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPut("milestones/{id}/complete")]
    public async Task<ActionResult<PregnancyMilestoneDto>> UpdateMilestoneStatus(Guid id, [FromBody] bool isCompleted)
    {
        try
        {
            var milestone = await _pregnancyService.UpdateMilestoneAsync(id, isCompleted);
            return Ok(milestone);
        }
        catch (ValidationException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("milestones/{id}")]
    public async Task<IActionResult> DeleteMilestone(Guid id)
    {
        try
        {
            await _pregnancyService.DeleteMilestoneAsync(id);
            return NoContent();
        }
        catch (ValidationException ex)
        {
            return NotFound(ex.Message);
        }
    }
    #endregion
} 