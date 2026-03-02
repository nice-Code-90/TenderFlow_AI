using TenderFlow_AI.Domain.Interfaces;

namespace TenderFlow_AI.Domain.Entities;

/// <summary>
/// Represents a specific skill or qualification held by an employee.
/// </summary>
public class EmployeeSkill : ITenantEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrganizationId { get; set; } 
    
    /// <summary>
    /// The name/key of the skill (e.g., "AgileExperience", "SecurityClearance").
    /// </summary>
    public string SkillName { get; set; } 

    /// <summary>
    /// The value of the skill, stored as string for flexibility. 
    /// Can be "5" for years, "Expert" for levels, or "True" for certifications.
    /// </summary>
    public string Value { get; set; }
}