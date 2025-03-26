using MomCarePlus.Domain.Enums;

namespace MomCarePlus.Application.DTOs.Auth;

public class AuthResponseDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public UserType UserType { get; set; }
    public string Token { get; set; }
} 