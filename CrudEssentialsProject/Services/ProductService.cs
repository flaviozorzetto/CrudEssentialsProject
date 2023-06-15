using CrudEssentialsProject.Interfaces;
using CrudEssentialsProject.Models.Dto;
using CrudEssentialsProject.Services.Enums;
using MySqlConnector;

namespace CrudEssentialsProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ServiceResponse<ProductResponse>> AddNewProduct(ProductRequest productRequest)
        {
            try
            {
                var product = await _productRepository.Create(productRequest);
                return new ServiceResponse<ProductResponse>() { Message = product, Status = ServiceResponseStatus.SUCCESS };
            }
            catch (MySqlException ex)
            {
                return new ServiceResponse<ProductResponse>() { ErrorMessage = ex.Message, Status = ServiceResponseStatus.BAD_REQUEST };
            }
        }

        public async Task<ServiceResponse<IList<ProductResponse>>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            return new ServiceResponse<IList<ProductResponse>>() { Message = products, Status = ServiceResponseStatus.SUCCESS };
        }

        public async Task<ServiceResponse<ProductResponse>> GetProductByName(string name)
        {
            var product = await _productRepository.GetByName(name);

            if (product == null)
            {
                return new ServiceResponse<ProductResponse>() { ErrorMessage = "Product not found", Status = ServiceResponseStatus.NOT_FOUND };
            }
            return new ServiceResponse<ProductResponse>() { Message = product, Status = ServiceResponseStatus.SUCCESS };
        }
    }
}
