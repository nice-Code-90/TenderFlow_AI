using System.Collections.Generic;

namespace TenderFlow_AI.Application.Contracts.DTOs.Employees;

public class EmployeeDto
{
    public string Name { get; set; }
    public string Bio { get; set; }
    public List<EmployeeSkillDto> Skills { get; set; } = new();
}
