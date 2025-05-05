using Microsoft.EntityFrameworkCore;
using SmartStockAPI.Data;
using SmartStockAPI.Data.DTOs.Product;

namespace SmartStockAPI.Repositories.Product;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(ApplicationDbContext context, ILogger<ProductRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ProductModel?> CreateProductAsync(ProductModel product)
    {
        try
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product {product.Name} created successfully.");
            return product;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error creating product {product.Name}: {ex.Message}");
            return null;
        }
    }

    public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
    {
        try
        {
            var products = await _context.Products.ToListAsync();
            _logger.LogInformation($"Retrieved {products.Count} products.");
            return products;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving products.");
            return Enumerable.Empty<ProductModel>();
        }
    }

    public async Task<ProductModel?> GetProductByIdAsync(Guid id)
    {
        try
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                _logger.LogWarning($"Product with ID {id} not found.");
                return null;
            }
            _logger.LogInformation($"Product with ID {id} retrieved successfully.");
            return product;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving product with ID {id}: {ex.Message}");
            return null;
        }
    }

    public async Task<ProductModel?> UpdateProductAsync(Guid id, UpdateProductDTO product)
    {
        try
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                _logger.LogWarning($"Product with ID {id} not found.");
                return null;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.CostPrice = product.CostPrice;
            existingProduct.SalePrice = product.SalePrice;
            existingProduct.QuantityInStock = product.QuantityInStock;
            existingProduct.LastUpdateDate = DateTime.UtcNow;
            existingProduct.IsActive = product.IsActive;

            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product with ID {id} updated successfully.");
            return existingProduct;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error updating product with ID {id}: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        try
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                _logger.LogWarning($"Product with ID {id} not found.");
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product with ID {id} deleted successfully.");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error deleting product with ID {id}: {ex.Message}");
            return false;
        }
    }

    public async Task<IEnumerable<ProductModel>> SearchProductsAsyncByName(string name)
    {
        try
        {
            var products = await _context.Products
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();

            if (products.Count == 0)
            {
                _logger.LogWarning($"No products found with name containing '{name}'.");
                return Enumerable.Empty<ProductModel>();
            }

            _logger.LogInformation($"Found {products.Count} products with name containing '{name}'.");
            return products;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error searching products by name '{name}': {ex.Message}");
            return Enumerable.Empty<ProductModel>();
        }
    }
}
