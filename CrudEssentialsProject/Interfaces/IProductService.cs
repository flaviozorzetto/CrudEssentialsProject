using CrudEssentialsProject.Models.Dto;

namespace CrudEssentialsProject.Interfaces
{
    public interface IProductService
    {
        Task<IList<ProductResponse>> GetAllProducts();
        Task<ProductResponse> AddNewProduct(ProductRequest productRequest);
        Task<ProductResponse?> GetProductByName(string name);
    }
}
