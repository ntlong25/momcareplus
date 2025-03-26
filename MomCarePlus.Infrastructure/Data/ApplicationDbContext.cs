using Microsoft.EntityFrameworkCore;
using MomCarePlus.Domain.Entities;

namespace MomCarePlus.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<PregnancyProfile> PregnancyProfiles { get; set; }
    public DbSet<HealthTracking> HealthTrackings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.HasIndex(e => e.Email).IsUnique();
        });

        modelBuilder.Entity<PregnancyProfile>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Height).HasPrecision(5, 2);
            entity.Property(e => e.StartWeight).HasPrecision(5, 2);
            entity.Property(e => e.CurrentWeight).HasPrecision(5, 2);
            entity.Property(e => e.BloodType).HasMaxLength(5);
            entity.Property(e => e.RhFactor).HasMaxLength(2);
            entity.Property(e => e.MedicalHistory).HasMaxLength(1000);
            
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<HealthTracking>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Weight).HasPrecision(5, 2);
            entity.Property(e => e.Symptoms).HasMaxLength(500);
            entity.Property(e => e.Notes).HasMaxLength(1000);
            
            entity.HasOne(e => e.PregnancyProfile)
                .WithMany()
                .HasForeignKey(e => e.PregnancyProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
} 