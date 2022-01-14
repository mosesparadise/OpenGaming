namespace OpenGaming.Api.Infrastructure.Entities;

public class Event : AuditableEntity, IStatus
{
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public DateTime EventDateTime { get; set; }
    public EventStatusType StatusType { get; set; }
    public string EventStatusDescription { get; set; }
    public decimal Amount { get; set; }
    public Guid PunterId { get; set; }
    public Guid OperatorId { get; set; }
    public Punter Punter { get; set; }
    public Operator Operator { get; set; }
    public bool Status { get; set; }
}