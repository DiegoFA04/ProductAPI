using ProductAPI.Products.Domain.Model.Commands;
using ProductAPI.Products.Interfaces.REST.Resources;

namespace ProductAPI.Products.Interfaces.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(resource.Name, resource.Price, resource.Stock);
    }
}