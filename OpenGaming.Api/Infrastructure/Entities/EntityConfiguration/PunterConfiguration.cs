using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OpenGaming.Api.Infrastructure.Entities.EntityConfiguration;

public class PunterConfiguration : IEntityTypeConfiguration<Punter>
{
    public void Configure(EntityTypeBuilder<Punter> builder)
    {
        builder.AddIdGuidValueGenerator();
    }
}