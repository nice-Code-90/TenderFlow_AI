using TenderFlow_AI.Domain.Interfaces;

namespace TenderFlow_AI.Domain.Entities;

public class TenderConstraint : ITenantEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrganizationId { get; set; } 
    public string Key { get; set; }  
    public string Value { get; set; } 
}