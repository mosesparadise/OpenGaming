using OpenGaming.Api.Model;

namespace OpenGaming.Api.Infrastructure.Entities;

public class Punter : AuditableEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public PunterRiskLevel? RiskLevel { get; set; }
}