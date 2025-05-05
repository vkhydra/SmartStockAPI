using SmartStockAPI.Repositories.Product;

namespace SmartStockAPI.UseCases.Products.GetAll;

    public class GetAllProductsUseCase : IGetAllProductsUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductModel>> ExecuteAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }
    }
