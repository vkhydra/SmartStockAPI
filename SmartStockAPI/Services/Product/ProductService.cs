using SmartStockAPI.Data.DTOs.Product;
using SmartStockAPI.Repositories.Product;

namespace SmartStockAPI.Services.Product;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductModel> GetProductByIdAsync(Guid id)
    {
        return await _productRepository.GetProductByIdAsync(id);
    }

    public async Task<IEnumerable<ProductModel>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllProductsAsync();
    }
    public async Task<ProductModel> CreateProductAsync(ProductModel product)
    {
        return await _productRepository.CreateProductAsync(product);
    }
    public async Task<ProductModel> UpdateProductAsync(Guid id, UpdateProductDTO product)
    {
        return await _productRepository.UpdateProductAsync(id, product);
    }
    public async Task<bool> DeleteProductAsync(Guid id)
    {
        return await _productRepository.DeleteProductAsync(id);
    }
    public async Task<IEnumerable<ProductModel>> SearchProductsAsyncByName(string name)
    {
        return await _productRepository.SearchProductsAsyncByName(name);
    }    
}