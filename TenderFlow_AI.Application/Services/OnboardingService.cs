using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Application.Factories;
using TenderFlow_AI.Domain.Entities;

namespace TenderFlow_AI.Application.Services;

public class OnboardingService
{
    private readonly IUnitOfWork _uow;

    public OnboardingService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task CompleteOnboardingAsync(Guid orgId, string industry)
    {
        
        var existingOrg = await _uow.Organizations.GetByIdAsync(orgId);
        if (existingOrg != null)
        {
            return; 
        }

        
        var organization = new Organization
        {
            Id = orgId,
            Name = "TenderFlow Solutions", 
            Industry = industry
        };
        await _uow.Organizations.AddAsync(organization);

        
        var defaultEmployee = new Employee
        {
            Name = "John Doe (Lead Developer)",
            Bio = "Expert in GIS-like systems and Agile/Scrum methodologies. 6 years of C#/.NET experience compatible with Windows 11.",
            OrganizationId = orgId
        };
        await _uow.Employees.AddAsync(defaultEmployee);

        var defaultProject = new CompanyProject
        {
            ProjectName = "GIS-Map Viewer 2.0",
            Description = "A software system for contextual visualization and processing of geo-tagged data.",
            OrganizationId = orgId
        };
        await _uow.CompanyProjects.AddAsync(defaultProject);

        
        var defaultRules = IndustryContextFactory.GetDefaultRules(industry);
        foreach (var rule in defaultRules)
        {
            rule.OrganizationId = orgId;
            await _uow.OrganizationContexts.AddAsync(rule);
        }
        
        
        await _uow.OrganizationContexts.AddAsync(new OrganizationContext
        {
            MappingKey = "Warranty",
            Description = "Project warranty period in months",
            DefaultTargetValue = "24 months",
            OrganizationId = orgId
        });
        
        await _uow.OrganizationContexts.AddAsync(new OrganizationContext
        {
            MappingKey = "Documentation Language",
            Description = "Language for all official documentation",
            DefaultTargetValue = "English",
            OrganizationId = orgId
        });

        
        await _uow.SaveChangesAsync();
    }

    public async Task<List<OrganizationContext>> GetOrganizationContextsAsync(Guid organizationId)
    {
        return await _uow.OrganizationContexts.GetByOrgIdAsync(organizationId);
    }
}
