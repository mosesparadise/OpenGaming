namespace OpenGaming.Api.Infrastructure.Entities;

public class Operator : AuditableEntity
{
    public string OperatorName { get; set; }
    public string LicenceCode { get; set; }
    public string Region { get; set; }
    public List<Event> Events { get; set; }
}