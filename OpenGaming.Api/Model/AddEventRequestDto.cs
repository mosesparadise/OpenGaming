using OpenGaming.Api.Infrastructure.Entities;

namespace OpenGaming.Api.Model;

public class AddEventRequestDto //: BaseRequestDto
{
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public DateTime EventDateTime { get; set; }
    public EventStatusType? StatusType { get; set; }
    public string? EventStatusDescription { get; set; }
}