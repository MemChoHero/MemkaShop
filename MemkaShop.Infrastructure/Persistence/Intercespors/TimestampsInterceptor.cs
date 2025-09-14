using MemkaShop.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MemkaShop.Infrastructure.Persistence.Intercespors;

public class TimestampsInterceptor : SaveChangesInterceptor
{
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result, 
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is DbContext context)
        {
            var createdEntries = context.ChangeTracker
                .Entries<IHasTimestamps>()
                .Where(e => e.State == EntityState.Added);

            foreach (var entry in createdEntries)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }

            var updatedEntries = context.ChangeTracker
                .Entries<IHasTimestamps>()
                .Where(e => e.State != EntityState.Modified);

            foreach (var entry in updatedEntries)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }

        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
