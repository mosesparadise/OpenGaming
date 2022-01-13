using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OpenGaming.Api.Infrastructure;
using OpenGaming.Api.Infrastructure.Entities;
using OpenGaming.Api.Model;

namespace OpenGaming.Api.Services;

public class PunterService : IPunterService
{
    private readonly GamingContext _context;
    private readonly ILogger<PunterService> _logger;
    private readonly IMapper _mapper;

    public PunterService(GamingContext context, IMapper mapper, ILogger<PunterService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<AddPunterResponseDto?> AddPunter(AddPunterRequestDto requestDto,
        CancellationToken cancellationToken)
    {
        var punter = _mapper.Map<Punter>(requestDto);
        try
        {
            _context.Punters.Add(punter);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            return null;
        }

        return _mapper.Map<AddPunterResponseDto>(punter);
    }

    public async Task<PunterResponseDto?> GetPunter(Guid punterId, CancellationToken cancellationToken)
    {
        var punter =
            await _context.Punters.FirstOrDefaultAsync(x => x.Id == punterId, cancellationToken);
        if (punter == null)
            return null;
        return _mapper.Map<PunterResponseDto>(punter);
    }
}