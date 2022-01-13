namespace OpenGaming.Api.Infrastructure.Entities;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; }
}

public class BaseEntity : BaseEntity<Guid>
{
}