namespace TenderFlow_AI.Domain.Entities;

public class ProjectAttribute
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Key { get; set; }
    public string Value { get; set; }
}
