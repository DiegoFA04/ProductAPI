using ProductAPI.Products.Domain.Model.Aggregates;
using ProductAPI.Products.Domain.Model.Queries;
using ProductAPI.Products.Domain.Repositories;
using ProductAPI.Products.Domain.Services;
using ProductAPI.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ProductAPI.Products.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository) : IProductQueryService
{
  public async Task<Product?> Handle(GetProductByIdQuery query)
  {
    return await productRepository.FindByIdAsync(query.ProductId);
  }

  public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
  {

    return await productRepository.FindAllProducts();
  }

  public async Task<List<Product?>> Handle(GetProductsByStockQuery query)
  {
    return await productRepository.FindProductByStockAsync(query.Stock);
  }

  public async Task<Product?> Handle(GetProductByNameQuery query)
  {
    return await productRepository.FindProductByNameAsync(query.Name);
  }
}