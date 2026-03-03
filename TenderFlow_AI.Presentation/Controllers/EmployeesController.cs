using Microsoft.AspNetCore.Mvc;
using TenderFlow_AI.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Application.Contracts.DTOs.Employees;

namespace TenderFlow_AI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : BaseApiController
{
    private readonly EmployeeService _employeeService;
    private readonly ITenantProvider _tenantProvider;

    public EmployeesController(EmployeeService employeeService, ITenantProvider tenantProvider)
    {
        _employeeService = employeeService;
        _tenantProvider = tenantProvider;
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> BulkUploadEmployees([FromBody] List<EmployeeDto> employees)
    {
        if (employees == null || employees.Count == 0)
        {
            return BadRequest("Employee list cannot be null or empty.");
        }
        
        var organizationId =  _tenantProvider.GetTenantId();
        if (organizationId == Guid.Empty)
        {
            return Unauthorized("OrganizationId could not be determined.");
        }

        var result = await _employeeService.AddEmployeesBulkAsync(employees, organizationId);
        
        return HandleResult(result);
    }
}
