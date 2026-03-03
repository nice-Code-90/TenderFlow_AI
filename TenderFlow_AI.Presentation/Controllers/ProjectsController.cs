using Microsoft.AspNetCore.Mvc;
using TenderFlow_AI.Application.Services;
using TenderFlow_AI.Application.Contracts.DTOs.Projects;
using TenderFlow_AI.Presentation.Services;

namespace TenderFlow_AI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : BaseApiController
{
    private readonly ProjectService _projectService;

    public ProjectsController(ProjectService projectService, ApiResponseService apiResponseService) 
        : base(apiResponseService)
    {
        _projectService = projectService;
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> BulkUploadProjects([FromBody] List<CompanyProjectDto> projects)
    {
        return await ApiResponseService.HandleApiResponseAsync(orgId =>
            _projectService.AddProjectsBulkAsync(projects, orgId));
    }
}
