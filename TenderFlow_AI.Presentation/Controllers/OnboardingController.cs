using Microsoft.AspNetCore.Mvc;
using TenderFlow_AI.Application.Services;
using TenderFlow_AI.Presentation.Services;

namespace TenderFlow_AI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OnboardingController : BaseApiController
{
    private readonly OnboardingService _onboardingService;

    public OnboardingController(OnboardingService onboardingService, ApiResponseService apiResponseService)
        : base(apiResponseService)
    {
        _onboardingService = onboardingService;
    }

    [HttpPost]
    public async Task<IActionResult> CompleteOnboarding([FromBody] OnboardingRequest request)
    {
        // This action doesn't require a pre-validated tenant ID from the context,
        // as it's part of the onboarding request itself.
        // We use the HandleApiResponseAsync overload that takes the service method directly.
        return await ApiResponseService.HandleApiResponseAsync(() => 
            _onboardingService.CompleteOnboardingAsync(request.OrganizationId, request.Industry));
    }

    [HttpGet("{organizationId}")]
    public async Task<IActionResult> GetOrganizationContexts(Guid organizationId)
    {
        // This also uses the direct method call as the orgId is passed in the route.
        return await ApiResponseService.HandleApiResponseAsync(() => 
            _onboardingService.GetOrganizationContextsAsync(organizationId));
    }
}

public class OnboardingRequest
{
    public Guid OrganizationId { get; set; }
    public string Industry { get; set; }
}
