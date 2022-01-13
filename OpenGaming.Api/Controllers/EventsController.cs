using Microsoft.AspNetCore.Mvc;
using OpenGaming.Api.Model;
using OpenGaming.Api.Services;

namespace OpenGaming.Api.Controllers;

// [Authorize]
[Route("api/[controller]")]
// [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
[ApiController]
[Produces("application/json")]
public class EventsController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet("{eventId:guid}")]
    public async Task<IActionResult> Get(Guid eventId, CancellationToken cancellationToken)
    {
        var eventModel = await _eventService.GetEvent(eventId, cancellationToken);
        if (eventModel == null) return NotFound();
        return Ok(eventModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddEventRequestDto eventRequestDto, CancellationToken cancellationToken)
    {
        var eventModel = await _eventService.AddEvent(eventRequestDto, cancellationToken);
        if (eventModel == null) return BadRequest();
        return Ok(eventModel);
    }

    [HttpGet]
    [Route("punter/{punterId:guid}")]
    public async Task<IActionResult> GetPunterEvents(Guid punterId, CancellationToken cancellationToken)
    {
        var events = await _eventService.GetPunterEvents(punterId, cancellationToken);
        return Ok(events);
    }
}