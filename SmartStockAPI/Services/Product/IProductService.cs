using SmartStockAPI.Data.DTOs.Product;

namespace SmartStockAPI.Services.Product;

public interface IProductService
{
    Task<ProductModel> GetProductByIdAsync(Guid id);
    Task<IEnumerable<ProductModel>> GetAllProductsAsync();
    Task<ProductModel> CreateProductAsync(ProductModel product);
    Task<ProductModel> UpdateProductAsync(Guid id, UpdateProductDTO product);
    Task<bool> DeleteProductAsync(Guid id);    
    Task<IEnumerable<ProductModel>> SearchProductsAsyncByName(string name);
}