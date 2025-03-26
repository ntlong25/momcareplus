using MomCarePlus.Domain.Enums;

namespace MomCarePlus.Domain.DTOs.Auth;

public class RegisterDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public UserType UserType { get; set; }
} 