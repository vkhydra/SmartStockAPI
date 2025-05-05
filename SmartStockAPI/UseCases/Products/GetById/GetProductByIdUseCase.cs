using SmartStockAPI.Repositories.Product;

namespace SmartStockAPI.UseCases.Products.GetById;

public class GetProductByIdUseCase : IGetProductByIdUseCase
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductModel> ExecuteAsync(Guid id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        if (product == null)
        {
            throw new KeyNotFoundException($"Product with ID {id} not found.");
        }
        return product;
    }
}