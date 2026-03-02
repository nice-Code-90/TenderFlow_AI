namespace TenderFlow_AI.Domain.Entities;

using TenderFlow_AI.Domain.Interfaces;

/// <summary>
/// Represents a tenant (company/organization) in the SaaS platform.
/// </summary>
public class Organization
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Industry { get; set; } // e.g., "Software Development"
    
    /// <summary>
    /// Specific context rules defined during the onboarding wizard.
    /// </summary>
    public ICollection<OrganizationContext> ContextRules { get; set; } = new List<OrganizationContext>();
}

