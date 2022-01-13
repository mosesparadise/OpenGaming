using Microsoft.AspNetCore.Mvc;
using OpenGaming.Api.Model;
using OpenGaming.Api.Services;

namespace OpenGaming.Api.Controllers;

// [Authorize]
[Route("api/[controller]")]
// [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid eventId, CancellationToken cancellationToken)
    {
        var punter = await _eventService.GetEvent(eventId, cancellationToken);
        if (punter == null) return NotFound();
        return Ok(punter);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddEventRequestDto eventRequestDto, CancellationToken cancellationToken)
    {
        var eventModel = await _eventService.AddEvent(eventRequestDto, cancellationToken);
        if (eventModel == null) return BadRequest();
        return Ok(eventModel);
    }
}