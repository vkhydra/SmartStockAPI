namespace SmartStockAPI.UseCases.Products.GetAll;

public interface IGetAllProductsUseCase
{
    Task<IEnumerable<ProductModel>> ExecuteAsync();
}