namespace TenderFlow_AI.Domain.Entities;

public class CompanyProject
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string ProjectName { get; set; }
    public int YearsOfExperience { get; set; } // For GIS/Geo-localized software experience
    public ICollection<string> TechnologiesUsed { get; set; }
}
