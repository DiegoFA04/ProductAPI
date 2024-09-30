namespace ProductAPI.Products.Interfaces.REST.Resources;

public record ProductResource(int Id, string Name, decimal Price, int Stock);