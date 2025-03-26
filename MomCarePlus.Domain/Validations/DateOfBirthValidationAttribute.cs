using System.ComponentModel.DataAnnotations;

namespace MomCarePlus.Domain.Validations;

public class DateOfBirthValidationAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateOfBirth)
        {
            if (dateOfBirth > DateTime.UtcNow)
            {
                return new ValidationResult("Date of birth cannot be in the future");
            }
        }
        return ValidationResult.Success;
    }
} 