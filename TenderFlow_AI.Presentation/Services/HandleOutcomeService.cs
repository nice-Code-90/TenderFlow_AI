using Microsoft.AspNetCore.Mvc;
using TenderFlow_AI.Application.Common.Models;

namespace TenderFlow_AI.Presentation.Services; 

public class HandleOutcomeService
{
    public IActionResult HandleOutcome<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return new OkObjectResult(result.Value);
        }

        // Simple logic to determine status code based on error message.
        // This can be made more robust later.
        if (result.Error.Contains("Unauthorized", StringComparison.OrdinalIgnoreCase))
        {
            return new UnauthorizedObjectResult(result.Error);
        }
        
        // Default to BadRequest for other failures.
        return new BadRequestObjectResult(result.Error);
    }
}
