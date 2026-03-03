using Microsoft.AspNetCore.Mvc;
using TenderFlow_AI.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Application.Contracts.DTOs.Projects;

namespace TenderFlow_AI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : BaseApiController
{
    private readonly ProjectService _projectService;
    private readonly ITenantProvider _tenantProvider;

    public ProjectsController(ProjectService projectService, ITenantProvider tenantProvider)
    {
        _projectService = projectService;
        _tenantProvider = tenantProvider;
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> BulkUploadProjects([FromBody] List<CompanyProjectDto> projects)
    {
        if (projects == null || projects.Count == 0)
        {
            return BadRequest("Project list cannot be null or empty.");
        }

        var organizationId =  _tenantProvider.GetTenantId();
        if (organizationId == Guid.Empty)
        {
            return Unauthorized("OrganizationId could not be determined.");
        }

        var result = await _projectService.AddProjectsBulkAsync(projects, organizationId);
        
        return HandleResult(result);
    }
}
