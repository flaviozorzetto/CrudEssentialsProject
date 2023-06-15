using CrudEssentialsProject.Models.Dto;

namespace CrudEssentialsProject.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse<IList<ProductResponse>>> GetAllProducts();
        Task<ServiceResponse<ProductResponse>> AddNewProduct(ProductRequest productRequest);
        Task<ServiceResponse<ProductResponse>> GetProductByName(string name);
    }
}
