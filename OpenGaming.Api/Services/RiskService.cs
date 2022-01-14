using Microsoft.EntityFrameworkCore;
using OpenGaming.Api.Infrastructure;
using OpenGaming.Api.Infrastructure.Entities;
using OpenGaming.Api.Model;

namespace OpenGaming.Api.Services;

public class RiskService : IRiskService
{
    private readonly GamingContext _context;
    private readonly ILogger<RiskService> _logger;

    public RiskService(GamingContext context, ILogger<RiskService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<PunterRiskResponseDto> GetPunterRisk(PunterRiskRequestDto requestDto,
        CancellationToken cancellationToken)
    {
        var punters = await _context.Punters
            .Where(x => x.FirstName == requestDto.FirstName && x.LastName == requestDto.LastName &&
                        x.DateOfBirth == requestDto.DateOfBirth).ToListAsync(cancellationToken);
        if (!punters.Any())
            return new PunterRiskResponseDto {LastUpdated = DateTime.UtcNow, RiskLevel = PunterRiskLevel.None};

        var punter = punters.First();

        var punterEvents = await _context.Events.Where(x => x.PunterId == punter.Id && x.Status)
            .ToListAsync(cancellationToken);

        if (!punterEvents.Any() || punterEvents.All(x => x.StatusType != EventStatusType.Fraud))
            return new PunterRiskResponseDto {LastUpdated = DateTime.UtcNow, RiskLevel = PunterRiskLevel.None};

        return new PunterRiskResponseDto
            {LastUpdated = punters.Last().CreatedOn, RiskLevel = GetPunterRiskLevel(punterEvents)};
    }

    private PunterRiskLevel GetPunterRiskLevel(List<Event> punterEvents)
    {
        var average = punterEvents.Average(x => x.Amount);
        var count = punterEvents.Count / punterEvents.Count(x => x.StatusType == EventStatusType.Fraud);
        var fraudEvents = punterEvents.Where(x => x.StatusType == EventStatusType.Fraud).ToList();
        var transactionSum = punterEvents.Sum(x => x.Amount);
        var lastFraudDate = fraudEvents.Max(x => x.CreatedOn);

        var lastYear = GetDifferenceInYears(lastFraudDate, DateTime.UtcNow);

        if (lastYear <= 6)
            return PunterRiskLevel.VeryHigh;

        // if (fraudEvents.Count >= count && transactionSum >= average)
        //     return PunterRiskLevel.VeryHigh;
        //
        // if (punterEvents.Count(x => x.StatusType == EventStatusType.Fraud) > count)
        //     return PunterRiskLevel.High;
        //
        // if (punterEvents.Count(x => x.StatusType == EventStatusType.Fraud) > count)
        //     return PunterRiskLevel.Medium;
        //
        // if (punterEvents.Count(x => x.StatusType == EventStatusType.Fraud) > count)
        //     return PunterRiskLevel.Low;

        return PunterRiskLevel.Low;
    }

    private int GetDifferenceInYears(DateTime startDate, DateTime endDate)
    {
        //Excel documentation says "COMPLETE calendar years in between dates"
        var years = endDate.Year - startDate.Year;

        if (startDate.Month == endDate.Month && // if the start month and the end month are the same
            endDate.Day < startDate.Day // AND the end day is less than the start day
            || endDate.Month < startDate.Month) // OR if the end month is less than the start month
            years--;
        return years;
    }
}