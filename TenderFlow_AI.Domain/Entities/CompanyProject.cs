namespace TenderFlow_AI.Domain.Entities;

/// <summary>
/// Represents a past corporate project used as a reference to prove competence.
/// </summary>
public class CompanyProject
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string ProjectName { get; set; }

    /// <summary>
    /// Flexible collection of project metadata (e.g., "Industry" : "Defense", "Complexity" : "High").
    /// This allows the Semantic Matcher to find relevant references without hardcoded fields.
    /// </summary>
    public ICollection<ProjectAttribute> Attributes { get; set; } = new List<ProjectAttribute>();
}