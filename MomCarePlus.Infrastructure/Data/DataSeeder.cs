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

        // Seed PregnancyAdviceCategories
        var categories = new List<PregnancyAdviceCategory>
        {
            new PregnancyAdviceCategory
            {
                Id = Guid.NewGuid(),
                Name = "Dinh dưỡng",
                Description = "Các lời khuyên về dinh dưỡng cho mẹ bầu",
                CreatedAt = DateTime.UtcNow
            },
            new PregnancyAdviceCategory
            {
                Id = Guid.NewGuid(),
                Name = "Tập thể dục",
                Description = "Các bài tập an toàn cho mẹ bầu",
                CreatedAt = DateTime.UtcNow
            },
            new PregnancyAdviceCategory
            {
                Id = Guid.NewGuid(),
                Name = "Sức khỏe",
                Description = "Các lời khuyên về sức khỏe cho mẹ bầu",
                CreatedAt = DateTime.UtcNow
            }
        };

        modelBuilder.Entity<PregnancyAdviceCategory>().HasData(categories);

        // Seed PregnancyAdviceTags
        var tags = new List<PregnancyAdviceTag>
        {
            new PregnancyAdviceTag
            {
                Id = Guid.NewGuid(),
                Name = "Quan trọng",
                CreatedAt = DateTime.UtcNow
            },
            new PregnancyAdviceTag
            {
                Id = Guid.NewGuid(),
                Name = "Khẩn cấp",
                CreatedAt = DateTime.UtcNow
            },
            new PregnancyAdviceTag
            {
                Id = Guid.NewGuid(),
                Name = "Tham khảo",
                CreatedAt = DateTime.UtcNow
            }
        };

        modelBuilder.Entity<PregnancyAdviceTag>().HasData(tags);

        // Seed PregnancyAdvice
        var advices = new List<PregnancyAdvice>
        {
            new PregnancyAdvice
            {
                Id = Guid.NewGuid(),
                Title = "Dinh dưỡng trong tam cá nguyệt đầu",
                Content = "Trong tam cá nguyệt đầu, mẹ bầu nên bổ sung đầy đủ axit folic, sắt và canxi...",
                Stage = PregnancyStage.FirstTrimester,
                Type = AdviceType.Nutrition,
                IsRecommended = true,
                CreatedAt = DateTime.UtcNow
            },
            new PregnancyAdvice
            {
                Id = Guid.NewGuid(),
                Title = "Bài tập an toàn cho mẹ bầu",
                Content = "Các bài tập như đi bộ, bơi lội, yoga là những lựa chọn an toàn cho mẹ bầu...",
                Stage = PregnancyStage.SecondTrimester,
                Type = AdviceType.Exercise,
                IsRecommended = true,
                CreatedAt = DateTime.UtcNow
            },
            new PregnancyAdvice
            {
                Id = Guid.NewGuid(),
                Title = "Chuẩn bị tâm lý trước khi sinh",
                Content = "Việc chuẩn bị tâm lý trước khi sinh rất quan trọng...",
                Stage = PregnancyStage.ThirdTrimester,
                Type = AdviceType.Emotional,
                IsRecommended = true,
                CreatedAt = DateTime.UtcNow
            }
        };

        modelBuilder.Entity<PregnancyAdvice>().HasData(advices);

        // Seed PregnancyAdviceCategoryAdvices (Junction table)
        var adviceCategoryAdvices = new List<object>
        {
            new { AdvicesId = advices[0].Id, CategoriesId = categories[0].Id },
            new { AdvicesId = advices[1].Id, CategoriesId = categories[1].Id },
            new { AdvicesId = advices[2].Id, CategoriesId = categories[2].Id }
        };

        modelBuilder.Entity<PregnancyAdvice>()
            .HasMany(a => a.Categories)
            .WithMany(c => c.Advices)
            .UsingEntity(j => j.HasData(adviceCategoryAdvices));

        // Seed PregnancyAdviceTagAdvices (Junction table)
        var adviceTagAdvices = new List<object>
        {
            new { AdvicesId = advices[0].Id, TagsId = tags[0].Id },
            new { AdvicesId = advices[1].Id, TagsId = tags[1].Id },
            new { AdvicesId = advices[2].Id, TagsId = tags[2].Id }
        };

        modelBuilder.Entity<PregnancyAdvice>()
            .HasMany(a => a.Tags)
            .WithMany(t => t.Advices)
            .UsingEntity(j => j.HasData(adviceTagAdvices));
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