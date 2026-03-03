namespace TenderFlow_AI.Application.Contracts.DTOs.Projects;

public class CompanyProjectDto
{
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public List<ProjectAttributeDto> Attributes { get; set; } = new();
}
