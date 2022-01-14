using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OpenGaming.Api.Infrastructure.Entities.EntityConfiguration;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.AddIdGuidValueGenerator();
        builder.HasOne(x => x.Punter).WithMany(x => x.Events).HasForeignKey(x => x.PunterId);
        builder.HasOne(x => x.Operator).WithMany(x => x.Events).HasForeignKey(x => x.OperatorId);
        builder.Property(x => x.Amount).HasPrecision(14, 2);
        builder.Property(x => x.Status).HasDefaultValue(true);
    }
}