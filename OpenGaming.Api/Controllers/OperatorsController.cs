using Microsoft.AspNetCore.Mvc;
using OpenGaming.Api.Services;

namespace OpenGaming.Api.Controllers;

[Route("api/[controller]")]
// [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
[ApiController]
public class OperatorsController : ControllerBase
{
    private readonly IOperatorService _operatorService;

    public OperatorsController(IOperatorService operatorService)
    {
        _operatorService = operatorService;
    }

    [HttpGet("{operatorId:guid}")]
    public async Task<IActionResult> Get(Guid operatorId, CancellationToken cancellationToken)
    {
        var operatorModel = await _operatorService.GetOperator(operatorId, cancellationToken);
        if (operatorModel == null) return NotFound();
        return Ok(operatorModel);
    }

    [HttpGet]
    [Route("licence/{licenceCode:required}")]
    public async Task<IActionResult> GetByLicenceCode(string licenceCode, CancellationToken cancellationToken)
    {
        var operatorModel = await _operatorService.GetOperatorbyLicenceCode(licenceCode, cancellationToken);
        if (operatorModel == null) return NotFound();
        return Ok(operatorModel);
    }
}