using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace OpenGaming.Api.Infrastructure.Entities.EntityConfiguration;

public static class EntityConfigurationExtension
{
    public static void AddIdGuidValueGenerator<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseEntity
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasValueGenerator<GuidValueGenerator>();
    }
}