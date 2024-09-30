using ProductAPI.Products.Domain.Model.Aggregates;
using ProductAPI.Shared.Domain.Repositories;

namespace ProductAPI.Products.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    Task<Product?> FindProductByNameAsync(string name);
}