using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OpenGaming.Api.Infrastructure.Entities.EntityConfiguration;

public class OperatorConfiguration : IEntityTypeConfiguration<Operator>
{
    public void Configure(EntityTypeBuilder<Operator> builder)
    {
        builder.AddIdGuidValueGenerator();
        builder.Property(x => x.LicenceCode).IsRequired();
        builder.HasIndex(x => x.LicenceCode).IsUnique();
    }
}