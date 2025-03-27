
namespace MomCarePlus.Domain.Entities;

public class PregnancyAdviceCategory
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public List<PregnancyAdvice> Advices { get; set; } = new();
}
