using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OpenGaming.Api.Infrastructure;
using OpenGaming.Api.Model;

namespace OpenGaming.Api.Services;

public class OperatorService : IOperatorService
{
    private readonly GamingContext _context;
    private readonly ILogger<OperatorService> _logger;
    private readonly IMapper _mapper;

    public OperatorService(GamingContext context, IMapper mapper, ILogger<OperatorService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<OperatorResponseDto?> GetOperator(Guid operatorId, CancellationToken cancellationToken)
    {
        var operatorModel = await _context.Operators.FirstOrDefaultAsync(x => x.Id == operatorId, cancellationToken);
        if (operatorModel == null) return null;
        return _mapper.Map<OperatorResponseDto>(operatorModel);
    }

    public async Task<OperatorResponseDto?> GetOperatorbyLicenceCode(string licenceCode,
        CancellationToken cancellationToken)
    {
        var operatorModel =
            await _context.Operators.FirstOrDefaultAsync(x => x.LicenceCode == licenceCode, cancellationToken);
        if (operatorModel == null) return null;
        return _mapper.Map<OperatorResponseDto>(operatorModel);
    }
}