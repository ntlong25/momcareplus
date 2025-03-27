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
    public DbSet<PregnancyAdviceCategory> PregnancyAdviceCategories { get; set; }
    public DbSet<PregnancyAdviceTag> PregnancyAdviceTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure relationships
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

            // One-to-Many relationship with PregnancyMilestone
            entity.HasMany(u => u.Milestones)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.UserId)
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
            entity.HasMany(p => p.Milestones)
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

            // Many-to-Many relationship with Categories
            entity.HasMany(a => a.Categories)
                .WithMany(c => c.Advices)
                .UsingEntity(j => j.ToTable("PregnancyAdviceCategoryAdvices"));

            // Many-to-Many relationship with Tags
            entity.HasMany(a => a.Tags)
                .WithMany(t => t.Advices)
                .UsingEntity(j => j.ToTable("PregnancyAdviceTagAdvices"));

            // Indexes for better query performance
            entity.HasIndex(e => e.Stage);
            entity.HasIndex(e => e.Type);
        });

        modelBuilder.Entity<PregnancyMilestone>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.PregnancyProfileId).IsRequired();
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.Title).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            entity.Property(e => e.DueDate).IsRequired();
            entity.Property(e => e.IsCompleted).IsRequired();
            
            // Many-to-One relationship with PregnancyProfile
            entity.HasOne(m => m.PregnancyProfile)
                .WithMany(p => p.Milestones)
                .HasForeignKey(m => m.PregnancyProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One relationship with User
            entity.HasOne(m => m.User)
                .WithMany(u => u.Milestones)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes for better query performance
            entity.HasIndex(e => e.PregnancyProfileId);
            entity.HasIndex(e => e.UserId);
            entity.HasIndex(e => e.DueDate);
        });

        modelBuilder.Entity<PregnancyAdviceCategory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);

            // Many-to-Many relationship with Advices
            entity.HasMany(c => c.Advices)
                .WithMany(a => a.Categories)
                .UsingEntity(j => j.ToTable("PregnancyAdviceCategoryAdvices"));
        });

        modelBuilder.Entity<PregnancyAdviceTag>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);

            // Many-to-Many relationship with Advices
            entity.HasMany(t => t.Advices)
                .WithMany(a => a.Tags)
                .UsingEntity(j => j.ToTable("PregnancyAdviceTagAdvices"));
        });

        // Seed data
        DataSeeder.SeedData(modelBuilder);
    }
} 