namespace TenderFlow_AI.Domain.Entities;

public class Employee
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int JiraGitConfluenceExperienceYears { get; set; }
    public int ModernTechStackExperienceYears { get; set; }
    public bool IsAvailable { get; set; } = true;
}
