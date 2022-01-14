using Microsoft.AspNetCore.Mvc;
using OpenGaming.Api.Model;
using OpenGaming.Api.Services;

namespace OpenGaming.Api.Controllers;

// [Authorize]
[Route("api/[controller]")]
// [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
[ApiController]
public class RisksController : ControllerBase
{
    private readonly IRiskService _riskService;

    public RisksController(IRiskService riskService)
    {
        _riskService = riskService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(PunterRiskRequestDto requestDto, CancellationToken cancellationToken)
    {
        return Ok(await _riskService.GetPunterRisk(requestDto, cancellationToken));
    }
}