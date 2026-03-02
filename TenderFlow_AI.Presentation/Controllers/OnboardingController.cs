using Microsoft.AspNetCore.Mvc;
using TenderFlow_AI.Application.Services;
using TenderFlow_AI.Domain.Entities;

namespace TenderFlow_AI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OnboardingController : ControllerBase
{
    private readonly OnboardingService _onboardingService;

    public OnboardingController(OnboardingService onboardingService)
    {
        _onboardingService = onboardingService;
    }

    [HttpPost]
    public async Task<IActionResult> CompleteOnboarding([FromBody] OnboardingRequest request)
    {
        if (request == null || request.OrganizationId == Guid.Empty || string.IsNullOrWhiteSpace(request.Industry))
        {
            return BadRequest("OrganizationId and Industry are required.");
        }

        await _onboardingService.CompleteOnboardingAsync(request.OrganizationId, request.Industry);

        return Ok("Onboarding completed successfully.");
    }

    [HttpGet("{organizationId}")]
    public async Task<ActionResult<List<OrganizationContext>>> GetOrganizationContexts(Guid organizationId)
    {
        var contexts = await _onboardingService.GetOrganizationContextsAsync(organizationId);
        return Ok(contexts);
    }
}

public class OnboardingRequest
{
    public Guid OrganizationId { get; set; }
    public string Industry { get; set; }
}
