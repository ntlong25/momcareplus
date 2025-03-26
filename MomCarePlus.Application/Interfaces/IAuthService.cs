using MomCarePlus.Application.DTOs.Auth;

namespace MomCarePlus.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
    Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    Task<bool> ValidateUserAsync(string email, string password);
} 