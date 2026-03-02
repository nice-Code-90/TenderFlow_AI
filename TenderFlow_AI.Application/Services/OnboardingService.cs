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
        var organization = new Organization
        {
            Id = orgId,
            Name = $"{industry} Company",
            Industry = industry
        };
        
        await _uow.Organizations.AddAsync(organization);

        var defaultRules = IndustryContextFactory.GetDefaultRules(industry);

        foreach (var rule in defaultRules)
        {
            rule.OrganizationId = orgId;
            await _uow.OrganizationContexts.AddAsync(rule);
        }

        await _uow.SaveChangesAsync();
    }

    public async Task<List<OrganizationContext>> GetOrganizationContextsAsync(Guid organizationId)
    {
        return await _uow.OrganizationContexts.GetByOrgIdAsync(organizationId);
    }
}
