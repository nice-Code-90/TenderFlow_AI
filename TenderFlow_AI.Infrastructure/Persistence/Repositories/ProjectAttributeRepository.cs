using TenderFlow_AI.Domain.Entities;
using TenderFlow_AI.Domain.Interfaces;
using TenderFlow_AI.Infrastructure.Persistence;
using TenderFlow_AI.Infrastructure.Repositories;

namespace TenderFlow_AI.Infrastructure.Persistence.Repositories;

public class ProjectAttributeRepository : Repository<ProjectAttribute>, IProjectAttributeRepository
{
    public ProjectAttributeRepository(TenderFlowDbContext context) : base(context)
    {
    }
}
