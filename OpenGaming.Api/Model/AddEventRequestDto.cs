using System.ComponentModel.DataAnnotations;
using OpenGaming.Api.Infrastructure.Entities;
using OpenGaming.Api.Model.Validators;

namespace OpenGaming.Api.Model;

public class AddEventRequestDto //: BaseRequestDto
{
    public Guid PunterId { get; set; }

    [Required] public string EventName { get; set; }

    [Required] public string EventDescription { get; set; }

    [Required] public DateTime EventDateTime { get; set; }

    [Required] public EventStatusType StatusType { get; set; }

    [Required] public string EventStatusDescription { get; set; }
    [RequiredGreaterThanZero] public decimal Amount { get; set; }

    [Required] public Guid OperatorId { get; set; }
}