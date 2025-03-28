namespace MomCarePlus.Application.Interfaces;

public interface IEmailService
{
    Task SendPasswordResetEmailAsync(string to, string resetToken);
} 