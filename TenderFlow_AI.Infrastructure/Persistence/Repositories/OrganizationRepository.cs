using TenderFlow_AI.Domain.Entities;
using TenderFlow_AI.Domain.Interfaces;
using TenderFlow_AI.Infrastructure.Persistence;

namespace TenderFlow_AI.Infrastructure.Repositories;

public class OrganizationRepository : Repository<Organization>, IOrganizationRepository
{
    public OrganizationRepository(TenderFlowDbContext context) : base(context)
    {
    }
}
