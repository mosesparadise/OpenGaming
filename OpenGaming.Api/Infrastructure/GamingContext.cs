using Microsoft.EntityFrameworkCore;
using OpenGaming.Api.Infrastructure.Entities;

namespace OpenGaming.Api.Infrastructure;

public class GamingContext : DbContext
{
    public GamingContext(DbContextOptions<GamingContext> options) : base(options)
    {
    }

    public DbSet<Punter> Punters { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Operator> Operators { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GamingContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        BeforeSaving();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void BeforeSaving()
    {
        foreach (var entityEntry in ChangeTracker.Entries<AuditableEntity>())
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entityEntry.Entity.CreatedOn = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entityEntry.Entity.LastModifiedDate = DateTime.UtcNow;
                    break;
            }
    }
}