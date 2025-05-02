using Microsoft.EntityFrameworkCore;
using SmartStockAPI.Data;
using SmartStockAPI.Data.DTOs.Product;

namespace SmartStockAPI.Repositories.Product;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ProductRepository> _logger; // Adicionamos o logger

    public ProductRepository(ApplicationDbContext context, ILogger<ProductRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<ProductModel> CreateProductAsync(ProductModel product)
    {
        try
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product {product.Name} created successfully.");
            return product;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, $"Error creating product {product.Name}: {ex.Message}");
            throw new Exception("Error while creating the product in the database.", ex);   
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Unexpected error creating product {product.Name}: {ex.Message}");
            throw new Exception("An unexpected error occurred while creating the product.", ex);
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
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, $"Error retrieving products: {ex.Message}");
            throw new Exception("An error occurred while retrieving the products from database.", ex);
        }
        catch (System.Exception)
        {
            _logger.LogError("Unexpected error retrieving products.");
            throw new Exception("An unexpected error occurred while retrieving the products.");
        }
    }

    public async Task<ProductModel> GetProductByIdAsync(Guid id)
    {
        try
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                _logger.LogWarning($"Product with ID {id} not found.");
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }
            _logger.LogInformation($"Product with ID {id} retrieved successfully.");
            return product;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, $"Error retrieving product with ID {id}: {ex.Message}");
            throw new Exception("An error occurred while retrieving the product from database.", ex);
        }
        catch (System.Exception)
        {
            _logger.LogError($"Unexpected error retrieving product with ID {id}.");
            throw new Exception("An unexpected error occurred while retrieving the product.");
        }
    }

    public async Task<ProductModel> UpdateProductAsync(Guid id, UpdateProductDTO product)
    {
        try
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                _logger.LogWarning($"Product with ID {id} not found.");
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }
            
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.CostPrice = product.CostPrice;
            existingProduct.SalePrice = product.SalePrice;
            existingProduct.QuantityInStock = product.QuantityInStock;

            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product with ID {id} updated successfully.");
            return existingProduct;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, $"Error updating product with ID {id}: {ex.Message}");
            throw new Exception("An error occurred while updating the product in database.", ex);
        }
        catch (System.Exception)
        {
            _logger.LogError($"Unexpected error updating product with ID {id}.");
            throw new Exception("An unexpected error occurred while updating the product.");
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
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Product with ID {id} deleted successfully.");
            return true;
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, $"Error deleting product with ID {id}: {ex.Message}");
            throw new Exception("An error occurred while deleting the product from database.", ex);
        }
        catch (System.Exception)
        {
            _logger.LogError($"Unexpected error deleting product with ID {id}.");
            throw new Exception("An unexpected error occurred while deleting the product.");
        }
    }
}