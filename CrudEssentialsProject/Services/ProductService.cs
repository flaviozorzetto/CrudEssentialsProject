using CrudEssentialsProject.Interfaces;
using CrudEssentialsProject.Models.Dto;
using CrudEssentialsProject.Services.Enums;
using MySqlConnector;

namespace CrudEssentialsProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger)
        {
            _logger = logger;
            _productRepository = productRepository;
        }
        public async Task<ServiceResponseDto<ProductResponseDto>> AddNewProduct(ProductRequestDto productRequest)
        {
            try
            {
                _logger.LogInformation("Inserting new product in database");
                var product = await _productRepository.Create(productRequest);
                _logger.LogInformation("Product inserted successfully");
                return new ServiceResponseDto<ProductResponseDto>() { Message = product, Status = ServiceResponseStatus.SUCCESS };
            }
            catch (MySqlException ex)
            {
                _logger.LogError($"Error while inserting new product: {ex.Message}");
                return new ServiceResponseDto<ProductResponseDto>() { ErrorMessage = ex.Message, Status = ServiceResponseStatus.BAD_REQUEST };
            }
        }

        public async Task<ServiceResponseDto<IList<ProductResponseDto>>> GetAllProducts()
        {
            _logger.LogInformation("Retrieving all products from database");
            var products = await _productRepository.GetAll();
            _logger.LogInformation("Retrieved all products");
            return new ServiceResponseDto<IList<ProductResponseDto>>() { Message = products, Status = ServiceResponseStatus.SUCCESS };
        }

        public async Task<ServiceResponseDto<ProductResponseDto>> GetProductByName(string name)
        {
            _logger.LogInformation("Retrieving product by name from database");
            var product = await _productRepository.GetByName(name);

            if (product == null)
            {
                _logger.LogInformation($"Product not found with name {name}");
                return new ServiceResponseDto<ProductResponseDto>() { ErrorMessage = "Product not found", Status = ServiceResponseStatus.NOT_FOUND };
            }

            _logger.LogInformation($"Retrieved product with name {name}");
            return new ServiceResponseDto<ProductResponseDto>() { Message = product, Status = ServiceResponseStatus.SUCCESS };
        }
    }
}
