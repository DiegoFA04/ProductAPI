using ProductAPI.Products.Domain.Model.Commands;

namespace ProductAPI.Products.Domain.Model.Aggregates;

public partial class Product
{
    public int Id { get; }
    
    public string Name { get; private set; }
    
    public decimal Price { get; private set; }
    
    public int Stock { get; private set; }
    
    public Product(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }
    
    public Product(CreateProductCommand command)
    {
        Name = command.Name;
        Price = command.Price;
        Stock = command.Stock;
    }
    
    public void Update(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }
    
}