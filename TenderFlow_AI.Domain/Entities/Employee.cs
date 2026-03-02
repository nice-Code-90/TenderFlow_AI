namespace TenderFlow_AI.Domain.Entities;

public class Employee
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
    public ICollection<EmployeeSkill> Skills { get; set; } = new List<EmployeeSkill>();
}
