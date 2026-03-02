using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Application.Factories;
using TenderFlow_AI.Domain.Entities;

namespace TenderFlow_AI.Application.Services;

public class OnboardingService
{
    private readonly IOrganizationContextRepository _repository;

    public OnboardingService(IOrganizationContextRepository repository)
    {
        _repository = repository;
    }

    public async Task CompleteOnboardingAsync(Guid orgId, string industry)
    {
        
        var defaultRules = IndustryContextFactory.GetDefaultRules(industry);
        
        foreach (var rule in defaultRules)
        {
            rule.OrganizationId = orgId;
            await _repository.AddAsync(rule);
        }

        
        await _repository.SaveChangesAsync();
    }

    public async Task<List<OrganizationContext>> GetOrganizationContextsAsync(Guid organizationId)
    {
        return await _repository.GetByOrgIdAsync(organizationId);
    }
}
