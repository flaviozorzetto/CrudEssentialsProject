using CrudEssentialsProject.Models.Dto;

namespace CrudEssentialsProject.Interfaces
{
    public interface IProductService
    {
        Task<ServiceResponse> GetAllProducts();
        Task<ServiceResponse> AddNewProduct(ProductRequest productRequest);
        Task<ServiceResponse> GetProductByName(string name);
    }
}
