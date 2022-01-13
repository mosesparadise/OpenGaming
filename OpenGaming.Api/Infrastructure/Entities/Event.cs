using MessagePack.Formatters;
using OpenGaming.Api.Services;

namespace OpenGaming.Api.Infrastructure.Entities;

public class Event : AuditableEntity
{
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public DateTime EventDateTime { get; set; }
    public EventStatusType StatusType { get; set; }
    public string EventStatusDescription { get; set; }
    public Guid PunterId { get; set; }
    public Punter Punter { get; set; }
}