using MomCarePlus.Domain.DTOs.Auth;

namespace MomCarePlus.Domain.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
    Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    Task<bool> ValidateUserAsync(string email, string password);
} 