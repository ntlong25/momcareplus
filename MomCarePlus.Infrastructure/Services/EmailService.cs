using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MomCarePlus.Application.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;

namespace MomCarePlus.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<EmailService> _logger;

    public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public async Task SendPasswordResetEmailAsync(string to, string resetToken)
    {
        try
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("MomCarePlus", _configuration["Email:From"]));
            email.To.Add(new MailboxAddress("", to));
            email.Subject = "Reset Your Password - MomCarePlus";

            var builder = new BodyBuilder();
            
            builder.HtmlBody = $@"
                <h2>Reset Your Password</h2>
                <p>You have requested to reset your password. Use the following code to proceed:</p>
                <h1 style='color: #4CAF50; font-size: 32px; letter-spacing: 5px;'>{resetToken}</h1>
                <p>This code will expire in 10 minutes.</p>
                <p>If you did not request this password reset, please ignore this email.</p>
                <br>
                <p>Best regards,</p>
                <p>MomCarePlus Team</p>";

            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(
                _configuration["Email:SmtpServer"],
                int.Parse(_configuration["Email:SmtpPort"]),
                MailKit.Security.SecureSocketOptions.StartTls
            );

            await smtp.AuthenticateAsync(
                _configuration["Email:Username"],
                _configuration["Email:Password"]
            );

            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

            _logger.LogInformation("Password reset code sent successfully to {Email}", to);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send password reset code to {Email}", to);
            throw;
        }
    }
} 