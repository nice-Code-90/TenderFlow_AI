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

    public async Task<Result<int>> AddProjectsBulkAsync(List<CompanyProjectDto> projectDtos, Guid organizationId)
    {
        var projects = projectDtos.Select(dto => new CompanyProject
        {
            ProjectName = dto.ProjectName,
            Description = dto.Description,
            OrganizationId = organizationId,
            Attributes = dto.Attributes.Select(attrDto => new ProjectAttribute
            {
                Key = attrDto.Key,
                Value = attrDto.Value,
                OrganizationId = organizationId
            }).ToList()
        });

        await _uow.CompanyProjects.AddRangeAsync(projects);
        await _uow.SaveChangesAsync();

        return Result<int>.Success(projectDtos.Count);
    }
}
