using Microsoft.AspNetCore.Mvc;
using TenderFlow_AI.Application.Services;
using TenderFlow_AI.Application.Contracts.DTOs.Employees;
using TenderFlow_AI.Presentation.Services;

namespace TenderFlow_AI.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : BaseApiController
{
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService, ApiResponseService apiResponseService) 
        : base(apiResponseService)
    {
        _employeeService = employeeService;
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> BulkUploadEmployees([FromBody] List<EmployeeDto> employees)
    {
        return await ApiResponseService.HandleApiResponseAsync(orgId =>
            _employeeService.AddEmployeesBulkAsync(employees, orgId));
    }
}
