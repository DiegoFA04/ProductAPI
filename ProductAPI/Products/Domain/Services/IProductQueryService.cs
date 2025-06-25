using ProductAPI.Products.Domain.Model.Aggregates;
using ProductAPI.Products.Domain.Model.Queries;

namespace ProductAPI.Products.Domain.Services;

public interface IProductQueryService
{
  Task<Product?> Handle(GetProductByIdQuery query);

  Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);

  Task<List<Product?>> Handle(GetProductsByStockQuery query);

  Task<Product?> Handle(GetProductByNameQuery query);

}