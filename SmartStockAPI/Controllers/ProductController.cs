using Microsoft.AspNetCore.Mvc;
using SmartStockAPI.Data.DTOs.Product;
using SmartStockAPI.Services.Product;

namespace SmartStockAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductModel product)
    {
        if (product == null)
        {
            return BadRequest();
        }
        var createdProduct = await _productService.CreateProductAsync(product);
        return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDTO productDto)
    {
        if (productDto == null)
        {
            return BadRequest();
        }

        var updatedProduct = await _productService.UpdateProductAsync(id, productDto);

        if (updatedProduct == null)
        {
            return NotFound();
        }

        return Ok(updatedProduct);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        var deleted = await _productService.DeleteProductAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}