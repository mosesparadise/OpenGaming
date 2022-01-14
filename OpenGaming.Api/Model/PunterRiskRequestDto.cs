using System.ComponentModel.DataAnnotations;

namespace OpenGaming.Api.Model;

public class PunterRiskRequestDto //: BaseRequestDto
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public DateTime DateOfBirth { get; set; }
}