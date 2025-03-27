using MomCarePlus.Domain.Enums;

namespace MomCarePlus.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public PregnancyProfile? PregnancyProfile { get; set; }
        public List<PregnancyMilestone> Milestones { get; set; } = new();
    }
} 