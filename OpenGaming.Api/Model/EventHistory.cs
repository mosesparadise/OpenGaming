namespace OpenGaming.Api.Model;

public class EventHistory
{
    public DateTime EventDateTime { get; set; }
    public string? EventName { get; set; }
    public string? EventDescription { get; set; }
    public bool FlagState { get; set; }
}