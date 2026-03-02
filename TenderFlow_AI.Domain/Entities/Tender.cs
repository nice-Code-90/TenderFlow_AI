using System.Collections.Generic;
using TenderFlow_AI.Domain.Enums;
using TenderFlow_AI.Domain.Interfaces;

namespace TenderFlow_AI.Domain.Entities;

/// <summary>
/// Represents the core aggregate root for a Request for Proposal (RFP) process.
/// </summary>
public class Tender : ITenantEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid OrganizationId { get; set; } 
    public string IssuerName { get; set; }
    public string Title { get; set; }
    public decimal Budget { get; set; }
    public DateTime Deadline { get; set; }
    public TenderStatus Status { get; set; }

    public ICollection<TenderConstraint> Constraints { get; set; } = new List<TenderConstraint>();
    public ICollection<Requirement> Requirements { get; set; } = new List<Requirement>();
}