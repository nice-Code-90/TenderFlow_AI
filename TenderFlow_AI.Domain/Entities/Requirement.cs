using TenderFlow_AI.Domain.Enums;

namespace TenderFlow_AI.Domain.Entities;

public class Requirement
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid TenderId { get; set; }
    public Tender Tender { get; set; }
    public string Description { get; set; }
    public RequirementType RequirementType { get; set; }

    // For Staff/Vendor requirements
    public int? MinimumYearsOfExperience { get; set; } 

    // For functional requirements
    public ClassificationLevel? ClassificationLevel { get; set; }
}
