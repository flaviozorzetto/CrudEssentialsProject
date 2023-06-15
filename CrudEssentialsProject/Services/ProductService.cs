using CrudEssentialsProject.Interfaces;
using CrudEssentialsProject.Models.Dto;

namespace CrudEssentialsProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> AddNewProduct(ProductRequest productRequest)
        {
            return await _productRepository.Create(productRequest);
        }

        public async Task<IList<ProductResponse>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<ProductResponse?> GetProductByName(string name)
        {
            return await _productRepository.GetByName(name);
        }
    }
}
