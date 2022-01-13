using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OpenGaming.Api.Infrastructure;
using OpenGaming.Api.Infrastructure.Entities;
using OpenGaming.Api.Model;

namespace OpenGaming.Api.Services;

public class EventService : IEventService
{
    private readonly GamingContext _context;
    private readonly ILogger<EventService> _logger;
    private readonly IMapper _mapper;

    public EventService(GamingContext context, IMapper mapper, ILogger<EventService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<AddEventResponseDto?> AddEvent(AddEventRequestDto requestDto, CancellationToken cancellationToken)
    {
        var eventModel = _mapper.Map<Event>(requestDto);
        try
        {
            await _context.Events.AddAsync(eventModel);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return null;
        }

        return _mapper.Map<AddEventResponseDto>(eventModel);
    }

    public async Task<EventResponseDto?> GetEvent(Guid eventId, CancellationToken cancellationToken)
    {
        var eventModel = await
            _context.Events.FirstOrDefaultAsync(x => x.Id == eventId, cancellationToken);
        if (eventModel == null)
            return null;
        return _mapper.Map<EventResponseDto>(eventModel);
    }
}