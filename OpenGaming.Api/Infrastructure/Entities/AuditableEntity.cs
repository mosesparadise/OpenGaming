namespace OpenGaming.Api.Infrastructure.Entities;

public class AuditableEntity : BaseEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}