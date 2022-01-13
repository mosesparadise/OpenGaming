namespace OpenGaming.Api.Model;

public class PunterResponseDto : BaseResponseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public PunterRiskLevel? RiskLevel { get; set; }
}