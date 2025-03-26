namespace MomCarePlus.Domain.Entities
{
    public class PregnancyProfile
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime ExpectedDueDate { get; set; }
        public DateTime FirstDayOfLastMenstrualPeriod { get; set; }
        public int PregnancyWeek { get; set; }
        public decimal Height { get; set; }
        public decimal StartWeight { get; set; }
        public decimal CurrentWeight { get; set; }
        public string BloodType { get; set; }
        public string RhFactor { get; set; }
        public string MedicalHistory { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
} 