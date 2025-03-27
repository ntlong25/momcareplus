
namespace MomCarePlus.Domain.Entities;

public class PregnancyAdviceTag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    // Navigation properties
    public List<PregnancyAdvice> Advices { get; set; } = new();
}
