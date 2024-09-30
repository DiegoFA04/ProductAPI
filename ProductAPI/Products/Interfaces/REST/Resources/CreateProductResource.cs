namespace ProductAPI.Products.Interfaces.REST.Resources;

public record CreateProductResource(string Name, decimal Price,int Stock);