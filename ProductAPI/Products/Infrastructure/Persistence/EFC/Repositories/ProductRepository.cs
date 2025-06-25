using Microsoft.EntityFrameworkCore;
using ProductAPI.Products.Domain.Model.Aggregates;
using ProductAPI.Products.Domain.Repositories;
using ProductAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using ProductAPI.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ProductAPI.Products.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
  public Task<IEnumerable<Product>> FindAllProducts()
  {
    // quiero regresear todos los productos con status code 0
    // Esto es un ejemplo, puedes ajustar la consulta según tus necesidades
    var products = new List<Product>();
    return Context.Set<Product>()
      .Where(p => p.StatusCode == 0) // Assuming 0 is the status code for active products
      .ToListAsync()
      .ContinueWith(task => task.Result.AsEnumerable());
  }

  public Task<Product?> FindProductByNameAsync(string name)
  {
    return Context.Set<Product>().Where(p => p.Name == name).FirstOrDefaultAsync();
  }

  public Task<List<Product?>> FindProductByStockAsync(int stock) // Updated return type to match the interface
  {
    return Context.Set<Product>().Where(p => p.Stock == stock).Cast<Product?>().ToListAsync();
  }
}