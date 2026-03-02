namespace TenderFlow_AI.Domain.Interfaces;

/// <summary>
/// Interface to enforce data isolation in a multi-tenant environment.
/// </summary>
public interface ITenantEntity
{
    public Guid OrganizationId { get; set; }
}