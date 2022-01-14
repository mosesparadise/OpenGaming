using OpenGaming.Api.Model;

namespace OpenGaming.Api.Services;

public interface IRiskService
{
    Task<PunterRiskResponseDto> GetPunterRisk(PunterRiskRequestDto requestDto,
        CancellationToken cancellationToken);
}