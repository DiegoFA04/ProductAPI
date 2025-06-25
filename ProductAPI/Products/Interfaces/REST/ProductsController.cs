using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Products.Domain.Model.Commands;
using ProductAPI.Products.Domain.Model.Queries;
using ProductAPI.Products.Domain.Services;
using ProductAPI.Products.Interfaces.REST.Resources;
using ProductAPI.Products.Interfaces.REST.Transform;

namespace ProductAPI.Products.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProductsController(IProductCommandService productCommandService, IProductQueryService productQueryService)
    : ControllerBase
{
  [HttpGet]
  public async Task<IActionResult> GetAllProducts()
  {
    var getAllProductsQuery = new GetAllProductsQuery();
    var products = await productQueryService.Handle(getAllProductsQuery);
    var productResources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
    return Ok(productResources);
  }

  [HttpGet("{productId:int}")]
  public async Task<IActionResult> GetProductById(int productId)
  {
    var getProductByIdQuery = new GetProductByIdQuery(productId);
    var product = await productQueryService.Handle(getProductByIdQuery);
    if (product == null) return NotFound();
    var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
    return Ok(productResource);
  }

  [HttpGet("stock/{stock:int}")]
  public async Task<IActionResult> GetProductsBtStock([FromRoute] int stock)
  {
    var getProductsByStockQuery = new GetProductsByStockQuery(stock);
    var products = await productQueryService.Handle(getProductsByStockQuery);
    if (products is null || !products.Any()) return NotFound();
    var productResources = products
        .Where(product => product != null) // Ensure null products are filtered out
        .Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
    return Ok(productResources);
  }

  [HttpGet("name/{name}")]
  public async Task<IActionResult> GetProductByName([FromRoute] string name)
  {
    var product = await productQueryService.Handle(new GetProductByNameQuery(name));
    if (product is null) return NotFound();
    var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
    return Ok(productResource);
  }

  [HttpPost]
  public async Task<IActionResult> CreateProduct(CreateProductResource resource)
  {
    var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
    var product = await productCommandService.Handle(createProductCommand);
    if (product is null) return BadRequest();
    var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
    return CreatedAtAction(nameof(GetProductById), new { productId = productResource.Id }, productResource);
  }

  [HttpPut("{productId:int}")]
  public async Task<IActionResult> UpdateProduct(int productId, UpdateProductResource resource)
  {
    var updateProductCommand = UpdateProductCommandFromResourceAssembler.ToCommandFromResource(productId, resource);
    var product = await productCommandService.Handle(updateProductCommand);
    if (product is null) return NotFound();
    var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
    return Ok(productResource);
  }

  [HttpDelete("{productId:int}")]
  public async Task<IActionResult> DeleteProduct(int productId)
  {
    var deleteProductCommand = new DeleteProductCommand(productId);
    var result = await productCommandService.Handle(deleteProductCommand);
    if (!result) return NotFound();
    return Ok("Product Deleted Successfully!!");
  }

}