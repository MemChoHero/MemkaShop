using MemkaShop.Infrastructure.Persistence.Interfaces;

namespace MemkaShop.Infrastructure.Persistence.Models;

public class Product : IHasSlug, IHasTimestamps
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public string? Thumbnail { get; set; }
    public string? Slug { get; set; }
    public string SlugSource => Title!;

    public HashSet<Category> Categories { get; set; } = new();

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
