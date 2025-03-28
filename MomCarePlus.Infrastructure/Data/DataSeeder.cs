using Microsoft.EntityFrameworkCore;
using MomCarePlus.Domain.Entities;
using MomCarePlus.Domain.Enums;
using System.Security.Cryptography;
using System.Text;

namespace MomCarePlus.Infrastructure.Data;

public static class DataSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Users
        var users = new List<User>
        {
            new User
            {
                Id = Guid.NewGuid(),
                Email = "admin@momcareplus.com",
                PasswordHash = HashPassword("Admin@123"),
                FullName = "Admin User",
                UserType = UserType.Professional,
                CreatedAt = DateTime.UtcNow
            },
            new User
            {
                Id = Guid.NewGuid(),
                Email = "expert@momcareplus.com",
                PasswordHash = HashPassword("Expert@123"),
                FullName = "Expert User",
                UserType = UserType.Professional,
                CreatedAt = DateTime.UtcNow
            }
        };

        modelBuilder.Entity<User>().HasData(users);
    }

    private static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
} 