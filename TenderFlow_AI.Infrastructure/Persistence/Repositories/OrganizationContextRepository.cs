using Microsoft.EntityFrameworkCore;
using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Domain.Entities;
using TenderFlow_AI.Infrastructure.Persistence;

namespace TenderFlow_AI.Infrastructure.Repositories;

public class OrganizationContextRepository : IOrganizationContextRepository
{
    private readonly TenderFlowDbContext _context;

    public OrganizationContextRepository(TenderFlowDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(OrganizationContext context)
    {
        await _context.OrganizationContexts.AddAsync(context);
    }

    public async Task<List<OrganizationContext>> GetByOrgIdAsync(Guid organizationId)
    {
        return await _context.OrganizationContexts
            .Where(oc => oc.OrganizationId == organizationId)
            .ToListAsync();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
