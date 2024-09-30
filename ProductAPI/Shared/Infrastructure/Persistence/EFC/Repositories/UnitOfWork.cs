using ProductAPI.Shared.Domain.Repositories;
using ProductAPI.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ProductAPI.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync() => await context.SaveChangesAsync();
}