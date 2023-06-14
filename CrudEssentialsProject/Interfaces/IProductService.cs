using CrudEssentialsProject.Models.Dto;

namespace CrudEssentialsProject.Interfaces
{
    public interface IProductService
    {
        List<ProductResponse> getAllProducts();
        ProductResponse addNewProduct(ProductRequest productRequest);
        ProductResponse? getProductByName(string name);
    }
}
