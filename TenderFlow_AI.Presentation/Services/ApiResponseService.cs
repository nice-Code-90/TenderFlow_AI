using Microsoft.AspNetCore.Mvc;
using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Application.Common.Models;

namespace TenderFlow_AI.Presentation.Services; 

public class ApiResponseService
{
    private readonly ITenantProvider _tenantProvider;
    private readonly HandleOutcomeService _handleOutcomeService;

    public ApiResponseService(ITenantProvider tenantProvider, HandleOutcomeService handleOutcomeService)
    {
        _tenantProvider = tenantProvider;
        _handleOutcomeService = handleOutcomeService;
    }

    /// <summary>
    /// Handles API calls that require a validated Organization ID.
    /// </summary>
    public async Task<IActionResult> HandleApiResponseAsync<T>(Func<Guid, Task<Result<T>>> serviceMethodWithOrgId)
    {
        try
        {
            var organizationId =  _tenantProvider.GetTenantId();
            if (organizationId == Guid.Empty)
            {
                return _handleOutcomeService.HandleOutcome(Result<T>.Failure("Unauthorized: OrganizationId could not be determined."));
            }

            var result = await serviceMethodWithOrgId(organizationId);
            return _handleOutcomeService.HandleOutcome(result);
        }
        catch (Exception ex)
        {
            // Log the exception ex here...
            return _handleOutcomeService.HandleOutcome(Result<T>.Failure($"An unexpected error occurred: {ex.Message}"));
        }
    }

    /// <summary>
    /// Handles API calls that do not require a pre-validated Organization ID.
    /// </summary>
    public async Task<IActionResult> HandleApiResponseAsync<T>(Func<Task<Result<T>>> serviceMethod)
    {
        try
        {
            var result = await serviceMethod();
            return _handleOutcomeService.HandleOutcome(result);
        }
        catch (Exception ex)
        {
            // Log the exception ex here...
            return _handleOutcomeService.HandleOutcome(Result<T>.Failure($"An unexpected error occurred: {ex.Message}"));
        }
    }
}
