using TenderFlow_AI.Domain.Interfaces;

namespace TenderFlow_AI.Domain.Entities;

public class Employee : ITenantEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Bio { get; set; }
    public bool IsAvailable { get; set; } = true;
    public ICollection<EmployeeSkill> Skills { get; set; } = new List<EmployeeSkill>();
    public Guid OrganizationId { get; set; }
}
