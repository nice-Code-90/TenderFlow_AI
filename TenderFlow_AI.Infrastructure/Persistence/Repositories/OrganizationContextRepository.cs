using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Domain.Entities;
using TenderFlow_AI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
namespace TenderFlow_AI.Infrastructure.Repositories;


public class OrganizationContextRepository : Repository<OrganizationContext>, IOrganizationContextRepository
{
    public OrganizationContextRepository(TenderFlowDbContext context) : base(context)
    {
        
    }

    public async Task<List<OrganizationContext>> GetByOrgIdAsync(Guid organizationId)
    {
        return await _context.OrganizationContexts
            .Where(oc => oc.OrganizationId == organizationId)
            .ToListAsync();
    }
}