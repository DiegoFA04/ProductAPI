using ProductAPI.Products.Domain.Model.Aggregates;
using ProductAPI.Products.Interfaces.REST.Resources;

namespace ProductAPI.Products.Interfaces.REST.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product product)
    {
        return new ProductResource(
            product.Id,
            product.Name,
            product.Price,
            product.Stock);
    }
    
}