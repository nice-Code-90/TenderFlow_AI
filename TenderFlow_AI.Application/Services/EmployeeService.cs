using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Application.Common.Models;
using TenderFlow_AI.Application.Contracts.DTOs.Employees;
using TenderFlow_AI.Domain.Entities;

namespace TenderFlow_AI.Application.Services;

public class EmployeeService
{
    private readonly IUnitOfWork _uow;

    public EmployeeService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Result<int>> AddEmployeesBulkAsync(List<EmployeeDto> employeeDtos, Guid organizationId)
    {
        var employees = employeeDtos.Select(dto => new Employee
        {
            Name = dto.Name,
            Bio = dto.Bio,
            OrganizationId = organizationId,
            Skills = dto.Skills.Select(skillDto => new EmployeeSkill
            {
                SkillName = skillDto.SkillName,
                Value = skillDto.Value,
                OrganizationId = organizationId
            }).ToList()
        });

        await _uow.Employees.AddRangeAsync(employees);
        await _uow.SaveChangesAsync();

        return Result<int>.Success(employeeDtos.Count);
    }
}
