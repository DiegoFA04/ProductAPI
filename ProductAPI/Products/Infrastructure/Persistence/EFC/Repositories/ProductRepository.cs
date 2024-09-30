using Microsoft.EntityFrameworkCore;
using ProductAPI.Products.Domain.Model.Aggregates;
using ProductAPI.Products.Domain.Repositories;
using ProductAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using ProductAPI.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ProductAPI.Products.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    public Task<Product?> FindProductByNameAsync(string name)
    {
        return Context.Set<Product>().Where(p => p.Name == name).FirstOrDefaultAsync();
    }
}