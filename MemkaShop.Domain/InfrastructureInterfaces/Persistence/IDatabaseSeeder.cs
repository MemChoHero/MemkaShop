namespace MemkaShop.Domain.InfrastructureInterfaces.Persistence
{
    public interface IDatabaseSeeder
    {
        Task RunAsync();
    }
}
