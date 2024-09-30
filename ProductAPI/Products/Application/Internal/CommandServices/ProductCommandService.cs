using ProductAPI.Products.Domain.Model.Aggregates;
using ProductAPI.Products.Domain.Model.Commands;
using ProductAPI.Products.Domain.Repositories;
using ProductAPI.Products.Domain.Services;
using ProductAPI.Shared.Domain.Repositories;

namespace ProductAPI.Products.Application.Internal.CommandServices;

public class ProductCommandService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        var product = new Product(command);
        try
        {
            await productRepository.AddAsync(product);
            await unitOfWork.CompleteAsync();
            return product;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the product: {e.Message}");
            return null;
        }
    }

    public async Task<Product?> Handle(UpdateProductCommand command)
    {
        var product = await productRepository.FindByIdAsync(command.Id);
        if (product is null) return null;
        product.Update(command.Name, command.Price, command.Stock);
        productRepository.Update(product);
        await unitOfWork.CompleteAsync();
        return product;
    }

    public async Task<bool> Handle(DeleteProductCommand command)
    {
        var product = await productRepository.FindByIdAsync(command.Id);
        if (product is null) return false;
        productRepository.Remove(product);
        await unitOfWork.CompleteAsync();
        return true;
    }
}