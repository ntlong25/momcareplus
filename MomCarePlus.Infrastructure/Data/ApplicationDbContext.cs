using Microsoft.EntityFrameworkCore;
using MomCarePlus.Domain.Entities;
using MomCarePlus.Domain.Interfaces;

namespace MomCarePlus.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<PregnancyProfile> PregnancyProfiles { get; set; }
    public DbSet<PregnancyAdvice> PregnancyAdvices { get; set; }
    public DbSet<PregnancyMilestone> PregnancyMilestones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.HasIndex(e => e.Email).IsUnique();

            // One-to-One relationship with PregnancyProfile
            entity.HasOne(u => u.PregnancyProfile)
                .WithOne(p => p.User)
                .HasForeignKey<PregnancyProfile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PregnancyProfile>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.Stage).IsRequired();
            entity.Property(e => e.IsPlanningPregnancy).IsRequired();
            
            // One-to-One relationship with User
            entity.HasOne(p => p.User)
                .WithOne(u => u.PregnancyProfile)
                .HasForeignKey<PregnancyProfile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many relationship with PregnancyMilestone
            entity.HasMany<PregnancyMilestone>()
                .WithOne(m => m.PregnancyProfile)
                .HasForeignKey(m => m.PregnancyProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PregnancyAdvice>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.Title).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.Stage).IsRequired();
            entity.Property(e => e.Type).IsRequired();
            entity.Property(e => e.IsRecommended).IsRequired();

            // Indexes for better query performance
            entity.HasIndex(e => e.Stage);
            entity.HasIndex(e => e.Type);
        });

        modelBuilder.Entity<PregnancyMilestone>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.PregnancyProfileId).IsRequired();
            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            entity.Property(e => e.DueDate).IsRequired();
            entity.Property(e => e.IsCompleted).IsRequired();
            
            // Many-to-One relationship with PregnancyProfile
            entity.HasOne(m => m.PregnancyProfile)
                .WithMany()
                .HasForeignKey(m => m.PregnancyProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Index for better query performance
            entity.HasIndex(e => e.PregnancyProfileId);
            entity.HasIndex(e => e.DueDate);
        });
    }
} 