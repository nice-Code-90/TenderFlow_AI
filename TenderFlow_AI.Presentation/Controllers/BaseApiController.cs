using Microsoft.AspNetCore.Mvc;
using TenderFlow_AI.Presentation.Services;

namespace TenderFlow_AI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected readonly ApiResponseService ApiResponseService;

    public BaseApiController(ApiResponseService apiResponseService)
    {
        ApiResponseService = apiResponseService;
    }
}
