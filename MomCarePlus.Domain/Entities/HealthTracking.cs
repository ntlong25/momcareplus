namespace MomCarePlus.Domain.Entities
{
    public class HealthTracking
    {
        public Guid Id { get; set; }
        public Guid PregnancyProfileId { get; set; }
        public PregnancyProfile PregnancyProfile { get; set; }
        public DateTime TrackingDate { get; set; }
        public decimal Weight { get; set; }
        public int? BloodPressureSystolic { get; set; }
        public int? BloodPressureDiastolic { get; set; }
        public string Symptoms { get; set; }
        public int MentalHealthScore { get; set; } // 1-5 scale
        public string Notes { get; set; }
    }
} 