using ProductAPI.Products.Domain.Model.Aggregates;
using ProductAPI.Products.Domain.Model.Commands;

namespace ProductAPI.Products.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(CreateProductCommand command);
    
    Task<Product?> Handle(UpdateProductCommand command);
    Task<bool> Handle(DeleteProductCommand command);
}