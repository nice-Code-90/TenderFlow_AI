using TenderFlow_AI.Domain.Entities;

namespace TenderFlow_AI.Application.Factories;

public static class IndustryContextFactory
{
    public static List<OrganizationContext> GetDefaultRules(string industry)
    {
        return industry.ToLower() switch
        {
            "software" => new List<OrganizationContext>
            {
                new() { MappingKey = "Agile_Exp", Description = "Years of experience in Scrum/Agile delivery", DefaultTargetValue = "3" },
                new() { MappingKey = "Cloud_Native", Description = "Proficiency in AWS, Azure, or GCP", DefaultTargetValue = "True" },
                new() { MappingKey = "ISO_27001", Description = "Information Security Management System certification", DefaultTargetValue = "True" }
            },
            "construction" => new List<OrganizationContext>
            {
                new() { MappingKey = "Safety_Cert", Description = "Health and Safety Executive (HSE) compliance", DefaultTargetValue = "True" },
                new() { MappingKey = "Project_Scale", Description = "Maximum budget of a previously managed project", DefaultTargetValue = "1000000" },
                new() { MappingKey = "Fleet_Size", Description = "Number of heavy machinery units owned/leased", DefaultTargetValue = "5" }
            },
            _ => new List<OrganizationContext>() // Empty for unknown industries
        };
    }
}
