using ProductAPI.Products.Domain.Model.Commands;

namespace ProductAPI.Products.Domain.Model.Aggregates;

public partial class Product
{
  public int Id { get; }

  public string Name { get; private set; }

  public decimal Price { get; private set; }

  public int Stock { get; private set; }

  // status Code
  public byte StatusCode { get; private set; } = 0;

  public Product(string name, decimal price, int stock)
  {
    Name = name;
    Price = price;
    Stock = stock;
    StatusCode = 0; // Default status code
  }

  public Product(CreateProductCommand command)
  {
    Name = command.Name;
    Price = command.Price;
    Stock = command.Stock;
    StatusCode = 0; // Default status code
  }

  public void Update(string name, decimal price, int stock)
  {
    Name = name;
    Price = price;
    Stock = stock;
    StatusCode = 0;
  }

  public void Update(UpdateProductCommand command)
  {
    Name = command.Name;
    Price = command.Price;
    Stock = command.Stock;
    StatusCode = 0; // Reset status code on update
  }

  public void SoftDelete()
  {
    StatusCode = 1; // Assuming 1 is the status code for deleted products
  }
}