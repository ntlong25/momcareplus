using System.ComponentModel.DataAnnotations;
using MomCarePlus.Domain.Enums;
using MomCarePlus.Domain.Validations;

namespace MomCarePlus.Application.DTOs.Auth;

public class RegisterDto
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Full name is required")]
    [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    [DataType(DataType.Date)]
    [DateOfBirthValidation]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    public string PhoneNumber { get; set; }

    public UserType UserType { get; set; }
} 