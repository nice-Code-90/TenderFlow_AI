using Mapster;
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

    public async Task<Result<BulkResponseDto>> AddEmployeesBulkAsync(List<EmployeeDto> employeeDtos, Guid organizationId)
    {
        var employees = employeeDtos.Select(dto =>
        {
            var employee = dto.Adapt<Employee>();
            employee.OrganizationId = organizationId;
            foreach (var skill in employee.Skills)
            {
                skill.OrganizationId = organizationId;
            }
            return employee;
        }).ToList();

        await _uow.Employees.AddRangeAsync(employees);
        await _uow.SaveChangesAsync();

        return Result<BulkResponseDto>.Success(new BulkResponseDto
        {
            Count = employees.Count,
            Message = "Employees uploaded successfully"
        });
    }
}
