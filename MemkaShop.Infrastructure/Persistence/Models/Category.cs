using MemkaShop.Infrastructure.Persistence.Interfaces;

namespace MemkaShop.Infrastructure.Persistence.Models;

public class Category : IHasSlug, IHasTimestamps
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Slug { get; set; }
    public string SlugSource => Name!;

    public HashSet<Product> Products { get; set; } = new();

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
