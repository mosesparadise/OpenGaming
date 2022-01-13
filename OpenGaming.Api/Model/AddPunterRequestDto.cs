using System.ComponentModel.DataAnnotations;

namespace OpenGaming.Api.Model;

public class AddPunterRequestDto //: BaseRequestDto
{
    [Required] public string FirstName { get; set; }
    [Required] public string LastName { get; set; }
    [Required] public DateTime DateOfBirth { get; set; }
    [Required] public string Address { get; set; }
    [Required] public string PostCode { get; set; }
    [Required] public Guid OperatorId { get; set; }
}