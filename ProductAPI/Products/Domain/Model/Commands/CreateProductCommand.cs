namespace ProductAPI.Products.Domain.Model.Commands;

public record CreateProductCommand(string Name, decimal Price, int Stock);