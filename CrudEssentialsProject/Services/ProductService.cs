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
        public async Task<ServiceResponse> AddNewProduct(ProductRequest productRequest)
        {
            try
            {
                var product = await _productRepository.Create(productRequest);
                return new ServiceResponse() { Message = product, Status = ServiceResponseStatus.SUCCESS };
            }
            catch (MySqlException ex)
            {
                return new ServiceResponse() { Message = ex.Message, Status = ServiceResponseStatus.BAD_REQUEST };
            }
        }

        public async Task<ServiceResponse> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            return new ServiceResponse() { Message = products, Status = ServiceResponseStatus.SUCCESS };
        }

        public async Task<ServiceResponse> GetProductByName(string name)
        {
            var product = await _productRepository.GetByName(name);

            if (product == null)
            {
                return new ServiceResponse() { Message = "Product not found", Status = ServiceResponseStatus.NOT_FOUND };
            }
            return new ServiceResponse() { Message = product, Status = ServiceResponseStatus.SUCCESS };
        }
    }
}
