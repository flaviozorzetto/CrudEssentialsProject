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
        public async Task<ServiceResponse<ProductResponse>> AddNewProduct(ProductRequest productRequest)
        {
            try
            {
                _logger.LogInformation("Inserting new product in database");
                var product = await _productRepository.Create(productRequest);
                _logger.LogInformation("Product inserted successfully");
                return new ServiceResponse<ProductResponse>() { Message = product, Status = ServiceResponseStatus.SUCCESS };
            }
            catch (MySqlException ex)
            {
                _logger.LogError($"Error while inserting new product: {ex.Message}");
                return new ServiceResponse<ProductResponse>() { ErrorMessage = ex.Message, Status = ServiceResponseStatus.BAD_REQUEST };
            }
        }

        public async Task<ServiceResponse<IList<ProductResponse>>> GetAllProducts()
        {
            _logger.LogInformation("Retrieving all products from database");
            var products = await _productRepository.GetAll();
            _logger.LogInformation("Retrieved all products");
            return new ServiceResponse<IList<ProductResponse>>() { Message = products, Status = ServiceResponseStatus.SUCCESS };
        }

        public async Task<ServiceResponse<ProductResponse>> GetProductByName(string name)
        {
            _logger.LogInformation("Retrieving product by name from database");
            var product = await _productRepository.GetByName(name);

            if (product == null)
            {
                _logger.LogInformation($"Product not found with name {name}");
                return new ServiceResponse<ProductResponse>() { ErrorMessage = "Product not found", Status = ServiceResponseStatus.NOT_FOUND };
            }

            _logger.LogInformation($"Retrieved product with name {name}");
            return new ServiceResponse<ProductResponse>() { Message = product, Status = ServiceResponseStatus.SUCCESS };
        }
    }
}
