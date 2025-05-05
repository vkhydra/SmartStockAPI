using Microsoft.AspNetCore.Mvc;
using SmartStockAPI.UseCases.Products.GetAll;
using SmartStockAPI.UseCases.Products.GetById;

namespace SmartStockAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IGetAllProductsUseCase _getAllProductsUseCase;
    private readonly IGetProductByIdUseCase _getProductByIdUseCase;
    public ProductController(ILogger<ProductController> logger, IGetAllProductsUseCase getAllProductsUseCase, IGetProductByIdUseCase getProductByIdUseCase)
    {
        _logger = logger;
        _getAllProductsUseCase = getAllProductsUseCase;
        _getProductByIdUseCase = getProductByIdUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        try
        {
            var products = await _getAllProductsUseCase.ExecuteAsync();
            return Ok(products);
        }   
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while retrieving products.");
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        try
        {
            var product = await _getProductByIdUseCase.ExecuteAsync(id);
            return Ok(product);
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new { message = $"Product with ID {id} not found." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving product with ID {id}.");
            return StatusCode(500, new { message = "Internal server error while retrieving product." });
        }
    }


    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetProductById(Guid id)
    // {
    //     var product = await _productService.GetProductByIdAsync(id);
    //     if (product == null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(product);
    // }
    // [HttpPost]
    // public async Task<IActionResult> CreateProduct([FromBody] ProductModel product)
    // {
    //     if (product == null)
    //     {
    //         return BadRequest();
    //     }
    //     var createdProduct = await _productService.CreateProductAsync(product);
    //     return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
    // }

    // [HttpPut("{id}")]
    // public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDTO productDto)
    // {
    //     if (productDto == null)
    //     {
    //         return BadRequest();
    //     }

    //     var updatedProduct = await _productService.UpdateProductAsync(id, productDto);

    //     if (updatedProduct == null)
    //     {
    //         return NotFound();
    //     }

    //     return Ok(updatedProduct);
    // }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteProduct(Guid id)
    // {
    //     var deleted = await _productService.DeleteProductAsync(id);
    //     if (!deleted)
    //     {
    //         return NotFound();
    //     }
    //     return NoContent();
    // }
    // [HttpGet("search")]
    // public async Task<IActionResult> SearchProductsByName([FromQuery] string name)
    // {
    //     if (string.IsNullOrEmpty(name))
    //     {
    //         return BadRequest("Name parameter is required.");
    //     }

    //     var products = await _productService.SearchProductsAsyncByName(name);
    //     return Ok(products);
    // }
}