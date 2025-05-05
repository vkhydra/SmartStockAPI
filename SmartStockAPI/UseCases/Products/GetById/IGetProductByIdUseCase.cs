namespace SmartStockAPI.UseCases.Products.GetById;

public interface IGetProductByIdUseCase
{
    Task<ProductModel> ExecuteAsync(Guid id);
}