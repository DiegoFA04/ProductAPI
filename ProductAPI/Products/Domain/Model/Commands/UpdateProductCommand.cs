namespace ProductAPI.Products.Domain.Model.Commands;

public record UpdateProductCommand(int Id, string Name, decimal Price, int Stock);