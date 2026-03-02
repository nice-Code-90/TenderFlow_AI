using TenderFlow_AI.Domain.Enums;
using TenderFlow_AI.Domain.Interfaces;

namespace TenderFlow_AI.Domain.Entities;

/// <summary>
/// Represents a specific requirement extracted from an RFP/Tender document.
/// Designed for elastic comparison between tender demands and corporate capabilities.
/// </summary>
public class Requirement : ITenantEntity
{
    /// <summary>
    /// Unique identifier for the requirement.
    /// </summary>
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrganizationId { get; set; } 
    /// <summary>
    /// Reference to the parent Tender.
    /// </summary>
    public Guid TenderId { get; set; }
    public Tender Tender { get; set; }

    /// <summary>
    /// The raw text description of the requirement as found in the PDF.
    /// Example: "The contractor shall have a minimum of 4 years of Agile experience."
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Categorizes the requirement (e.g., Technical, Legal, Financial).
    /// </summary>
    public RequirementType RequirementType { get; set; }

    /// <summary>
    /// Defines how critical the requirement is (e.g., Mandatory for Go/No-Go decisions).
    /// </summary>
    public ImportanceLevel Importance { get; set; }

    // --- Dynamic Evaluation Fields ---

    /// <summary>
    /// The expected value stored as a string to maintain multi-type compatibility.
    /// Can represent numbers ("4"), specific labels ("OSI Protected"), or categories ("GIS").
    /// </summary>
    public string TargetValue { get; set; } 

    /// <summary>
    /// Instructs the AI Agent on the logic required for validation.
    /// GreaterThanOrEquals is used for numeric years, while MatchSemantic triggers LLM/Vector reasoning.
    /// </summary>
    public ComparisonOperator Operator { get; set; }

    /// <summary>
    /// Optional key used to map this requirement to specific company data fields
    /// during automated auditing (e.g., "YearsOfExperience", "ISO_Certification_Status").
    /// </summary>
    public string MappingKey { get; set; } 
}