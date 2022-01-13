using OpenGaming.Api.Model;

namespace OpenGaming.Api.Services;

public interface IPunterService
{
    Task<AddPunterResponseDto?> AddPunter(AddPunterRequestDto requestDto,
        CancellationToken cancellationToken);

    Task<PunterResponseDto?> GetPunter(Guid punterId, CancellationToken cancellationToken);
}