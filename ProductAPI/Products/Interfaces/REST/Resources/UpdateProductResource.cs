namespace ProductAPI.Products.Interfaces.REST.Resources;

public record UpdateProductResource(string Name, decimal Price, int Stock);