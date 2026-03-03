using Mapster;
using TenderFlow_AI.Application.Common.Interfaces;
using TenderFlow_AI.Application.Common.Models;
using TenderFlow_AI.Application.Contracts.DTOs.Projects;
using TenderFlow_AI.Domain.Entities;

namespace TenderFlow_AI.Application.Services;

public class ProjectService
{
    private readonly IUnitOfWork _uow;

    public ProjectService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Result<BulkResponseDto>> AddProjectsBulkAsync(List<CompanyProjectDto> projectDtos, Guid organizationId)
    {
        var projects = projectDtos.Select(dto =>
        {
            var project = dto.Adapt<CompanyProject>();
            project.OrganizationId = organizationId;
            foreach (var attribute in project.Attributes)
            {
                attribute.OrganizationId = organizationId;
            }
            return project;
        }).ToList();

        await _uow.CompanyProjects.AddRangeAsync(projects);
        await _uow.SaveChangesAsync();

        return Result<BulkResponseDto>.Success(new BulkResponseDto
        {
            Count = projects.Count,
            Message = "Projects uploaded successfully"
        });
    }
}
