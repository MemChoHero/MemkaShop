namespace MemkaShop.Infrastructure.Persistence.Interfaces
{
    public interface IHasSlug
    {
        public string? Slug { get; set; }
        public string SlugSource { get; }
    }
}
