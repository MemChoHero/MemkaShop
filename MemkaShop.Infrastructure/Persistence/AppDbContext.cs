using MemkaShop.Infrastructure.Persistence.Intercespors;
using MemkaShop.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace MemkaShop.Infrastructure.Persistence;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
    {
    }

    public AppDbContext() 
    {
    }

    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new SlugInterceptor());
        optionsBuilder.AddInterceptors(new TimestampsInterceptor());
    }
}

