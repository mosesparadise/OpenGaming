using OpenGaming.Api.Model;

namespace OpenGaming.Api.Services;

public interface IEventService
{
    Task<AddEventResponseDto?> AddEvent(AddEventRequestDto requestDto, CancellationToken cancellationToken);
    Task<EventResponseDto?> GetEvent(Guid eventId, CancellationToken cancellationToken);
}