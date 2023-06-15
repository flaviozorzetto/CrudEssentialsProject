using CrudEssentialsProject.Models.Dto;

namespace CrudEssentialsProject.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponseDto<IList<ProductResponseDto>>> GetAllProducts();
        Task<ServiceResponseDto<ProductResponseDto>> AddNewProduct(ProductRequestDto productRequest);
        Task<ServiceResponseDto<ProductResponseDto>> GetProductByName(string name);
    }
}
