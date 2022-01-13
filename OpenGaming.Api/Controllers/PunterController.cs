using Microsoft.AspNetCore.Mvc;
using OpenGaming.Api.Model;
using OpenGaming.Api.Services;

namespace OpenGaming.Api.Controllers;

// [Authorize]
[Route("api/[controller]")]
// [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
[ApiController]
public class PunterController : ControllerBase
{
    private readonly IPunterService _punterService;

    public PunterController(IPunterService punterService)
    {
        _punterService = punterService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid punterId, CancellationToken cancellationToken)
    {
        var punter = await _punterService.GetPunter(punterId, cancellationToken);
        if (punter == null) return NotFound();
        return Ok(punter);
    }

    [HttpPost]
    public async Task<IActionResult> Post(AddPunterRequestDto punterRequestDto, CancellationToken cancellationToken)
    {
        var punter = await _punterService.AddPunter(punterRequestDto, cancellationToken);
        if (punter == null) return BadRequest();
        return Ok(punter);
    }
}