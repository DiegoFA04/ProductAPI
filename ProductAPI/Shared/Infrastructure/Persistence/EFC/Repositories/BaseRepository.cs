using Microsoft.EntityFrameworkCore;
using ProductAPI.Shared.Domain.Repositories;
using ProductAPI.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ProductAPI.Shared.Infrastructure.Persistence.EFC.Repositories;

public abstract class BaseRepository<TEntity>(AppDbContext context) : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly AppDbContext Context = context;

    public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

    public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

    public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();
}