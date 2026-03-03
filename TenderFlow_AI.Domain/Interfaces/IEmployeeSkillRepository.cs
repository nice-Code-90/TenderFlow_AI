using TenderFlow_AI.Domain.Entities;

namespace TenderFlow_AI.Domain.Interfaces;

public interface IEmployeeSkillRepository : IRepository<EmployeeSkill>
{
    // For now, we don't need any specific methods beyond the generic repository.
    // This can be expanded later if custom queries are required.
}
