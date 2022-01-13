namespace OpenGaming.Api.Model;

public abstract class BaseResponseDto : BaseDto
{
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}