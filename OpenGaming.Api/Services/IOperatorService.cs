using OpenGaming.Api.Model;

namespace OpenGaming.Api.Services;

public interface IOperatorService
{
    Task<OperatorResponseDto?> GetOperator(Guid operatorId, CancellationToken cancellationToken);
    Task<OperatorResponseDto?> GetOperatorbyLicenceCode(string licenceCode, CancellationToken cancellationToken);
}