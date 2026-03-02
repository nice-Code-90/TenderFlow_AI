using TenderFlow_AI.Domain.Interfaces;

namespace TenderFlow_AI.Domain.Entities;


/// <summary>
/// Stores domain-specific knowledge to guide AI Agents.
/// </summary>
public class OrganizationContext : ITenantEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrganizationId { get; set; }

    /// <summary>
    /// The unique identifier for a business term (e.g., "GIS_Experience").
    /// Matches the "MappingKey" in Requirements.
    /// </summary>
    public string MappingKey { get; set; }

    /// <summary>
    /// Natural language description to help the AI Agent understand the context.
    /// </summary>
    public string Description { get; set; }

    public string DefaultTargetValue { get; set; }
}