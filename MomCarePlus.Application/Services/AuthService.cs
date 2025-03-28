using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MomCarePlus.Application.DTOs.Auth;
using MomCarePlus.Application.Interfaces;
using MomCarePlus.Domain.Entities;
using MomCarePlus.Domain.Extensions;
using MomCarePlus.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace MomCarePlus.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;
    private readonly IEmailService _emailService;

    public AuthService(
        IUserRepository userRepository, 
        IConfiguration configuration,
        ILogger<AuthService> logger,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _configuration = configuration;
        _logger = logger;
        _emailService = emailService;
    }

    public async Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto)
    {
        // Validate the DTO
        var validationContext = new ValidationContext(registerDto);
        var validationResults = new List<ValidationResult>();
        if (!Validator.TryValidateObject(registerDto, validationContext, validationResults, true))
        {
            throw new ValidationException(validationResults.First().ErrorMessage);
        }

        // Check if email already exists
        if (await _userRepository.ExistsAsync(registerDto.Email))
        {
            throw new ValidationException("Email already exists");
        }
        
        // Check if phone number already exists
        if (await _userRepository.ExistsAsync(registerDto.PhoneNumber))
        {
            throw new ValidationException("PhoneNumber already exists");
        }

        // Hash password
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

        var user = new User
        {
            Email = registerDto.Email,
            PasswordHash = passwordHash,
            FullName = registerDto.FullName,
            DateOfBirth = registerDto.DateOfBirth.ToUtc(),
            PhoneNumber = registerDto.PhoneNumber,
            UserType = registerDto.UserType
        };

        await _userRepository.CreateAsync(user);

        var token = GenerateJwtToken(user);

        return new AuthResponseDto
        {
            Id = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            UserType = user.UserType,
            Token = token
        };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
    {
        // Validate the DTO
        var validationContext = new ValidationContext(loginDto);
        var validationResults = new List<ValidationResult>();
        if (!Validator.TryValidateObject(loginDto, validationContext, validationResults, true))
        {
            throw new ValidationException(validationResults.First().ErrorMessage);
        }

        var user = await _userRepository.GetByEmailAsync(loginDto.Email);
        if (user == null)
        {
            throw new ValidationException("Invalid email or password");
        }

        if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
        {
            throw new ValidationException("Invalid email or password");
        }

        var token = GenerateJwtToken(user);

        return new AuthResponseDto
        {
            Id = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            UserType = user.UserType,
            Token = token
        };
    }

    public async Task<bool> ValidateUserAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            return false;
        }

        return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
    }

    public async Task<bool> ForgotPasswordAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            // Don't reveal that the user does not exist
            return true;
        }

        // Generate 6-digit code
        var code = RandomNumberGenerator.GetInt32(100000, 999999).ToString();
        var tokenExpiry = DateTime.UtcNow.AddMinutes(10); // Token expires in 10 minutes

        // Store code in user entity
        user.PasswordResetToken = code;
        user.PasswordResetTokenExpiry = tokenExpiry;
        await _userRepository.UpdateAsync(user);

        // Send email with reset code
        await _emailService.SendPasswordResetEmailAsync(email, code);

        return true;
    }

    public async Task<bool> ResetPasswordAsync(string email, string token, string newPassword)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            return false;
        }

        if (user.PasswordResetToken != token || 
            user.PasswordResetTokenExpiry == null || 
            user.PasswordResetTokenExpiry < DateTime.UtcNow)
        {
            return false;
        }

        // Hash new password
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        user.PasswordHash = passwordHash;
        user.PasswordResetToken = null;
        user.PasswordResetTokenExpiry = null;

        await _userRepository.UpdateAsync(user);
        return true;
    }

    private string GenerateJwtToken(User user)
    {
        try
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            var jwtKey = _configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new InvalidOperationException("JWT Key is not configured");
            }

            _logger.LogInformation("Generating JWT token for user {UserId} with key length {KeyLength}", 
                user.Id, jwtKey.Length);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.UserType.ToString())
            };

            _logger.LogInformation("Creating JWT token with claims: {Claims}", 
                string.Join(", ", claims.Select(c => $"{c.Type}={c.Value}")));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            if (string.IsNullOrEmpty(tokenString))
            {
                throw new InvalidOperationException("Failed to generate JWT token");
            }

            _logger.LogInformation("Successfully generated JWT token for user {UserId}", user.Id);
            return tokenString;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating JWT token for user {UserId}. Exception: {ExceptionMessage}", 
                user?.Id, ex.Message);
            throw new InvalidOperationException("Error generating JWT token", ex);
        }
    }
} 