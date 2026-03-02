using TenderFlow_AI.Domain.Entities;

namespace TenderFlow_AI.Application.Common.Interfaces;

public interface IOrganizationContextRepository
{
    Task AddAsync(OrganizationContext context);
    Task<List<OrganizationContext>> GetByOrgIdAsync(Guid organizationId);
    
}
