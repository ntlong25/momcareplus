using System.ComponentModel.DataAnnotations;

namespace MomCarePlus.Application.DTOs.Auth;

public class ResetPasswordDto
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Token is required")]
    public string Token { get; set; }

    [Required(ErrorMessage = "New password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string NewPassword { get; set; }
} 