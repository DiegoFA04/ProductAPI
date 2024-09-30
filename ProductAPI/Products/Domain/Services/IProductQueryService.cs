using ProductAPI.Products.Domain.Model.Aggregates;
using ProductAPI.Products.Domain.Model.Queries;

namespace ProductAPI.Products.Domain.Services;

public interface IProductQueryService
{
    Task<Product?> Handle(GetProductByIdQuery query);
    
    Task<IEnumerable<Product>> Handle(GetAllProductsQuery query);
    
}