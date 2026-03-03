using TenderFlow_AI.Domain.Entities;
using TenderFlow_AI.Domain.Interfaces;
using TenderFlow_AI.Infrastructure.Persistence;
using TenderFlow_AI.Infrastructure.Repositories;

namespace TenderFlow_AI.Infrastructure.Persistence.Repositories;

public class EmployeeSkillRepository : Repository<EmployeeSkill>, IEmployeeSkillRepository
{
    public EmployeeSkillRepository(TenderFlowDbContext context) : base(context)
    {
    }
}
