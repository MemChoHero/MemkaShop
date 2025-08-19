using MemkaShop.Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MemkaShop.Infrastructure.Persistence.Intercespors
{
    public class SlugInterceptor : SaveChangesInterceptor
    {
        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, 
            InterceptionResult<int> result, 
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is DbContext context)
            {
                var entries = context.ChangeTracker
                    .Entries<IHasSlug>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

                foreach (var entry in entries)
                {
                    if (string.IsNullOrWhiteSpace(entry.Entity.Slug))
                    {
                        var baseSlug = Slugify(entry.Entity.SlugSource);
                        var slug = baseSlug;
                        var i = 1;

                        var entityType = entry.Entity.GetType();
                        var method = typeof(SlugInterceptor)
                            .GetMethod(nameof(HasSlugAsync), BindingFlags.NonPublic | BindingFlags.Instance)!
                            .MakeGenericMethod(entityType);
                            
                        while (await (Task<bool>) method.Invoke(this, [context, baseSlug, cancellationToken])!)
                        {
                            slug = $"{baseSlug}-{i}";
                            i++;
                        }

                        entry.Entity.Slug = slug;
                    }
                }
            }

            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task<bool> HasSlugAsync<TEntity>(
            DbContext context,
            string slug,
            CancellationToken cancellationToken) where TEntity : class, IHasSlug
        {
            return await context.Set<TEntity>().AnyAsync(e => e.Slug == slug);
        }

        private string Slugify(string value)
        {
            value = value.ToLowerInvariant();
            value = Regex.Replace(value, @"[^a-z0-9\s-]", "");
            value = Regex.Replace(value, @"\s+", "-").Trim('-');
            value = Regex.Replace(value, "-{2,}", "-");
            return value;
        }
    }
}
