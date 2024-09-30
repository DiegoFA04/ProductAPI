using ProductAPI.Products.Domain.Model.Commands;
using ProductAPI.Products.Interfaces.REST.Resources;

namespace ProductAPI.Products.Interfaces.REST.Transform;

public static class UpdateProductCommandFromResourceAssembler
{
    public static UpdateProductCommand ToCommandFromResource(int id, UpdateProductResource resource)
    {
        return new UpdateProductCommand(id, resource.Name, resource.Price, resource.Stock);
    }
}