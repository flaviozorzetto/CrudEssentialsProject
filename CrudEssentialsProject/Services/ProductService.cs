using CrudEssentialsProject.Interfaces;
using CrudEssentialsProject.Models;
using CrudEssentialsProject.Models.Dto;

namespace CrudEssentialsProject.Services
{
    public class ProductService : IProductService
    {
        IList<Product> products = new List<Product>();

        public ProductResponse addNewProduct(ProductRequest productRequest)
        {
            var product = new Product()
            {
                Guid = Guid.NewGuid(),
                Description = productRequest.Description,
                Name = productRequest.Name,
                Price = productRequest.Price,
                Quantity = productRequest.Quantity,
            };

            products.Add(product);

            return product.ToProductResponse();
        }

        public List<ProductResponse> getAllProducts()
        {
            return products.Select(product => product.ToProductResponse()).ToList();
        }

        public ProductResponse? getProductByName(string name)
        {
            var product = products.FirstOrDefault(product =>
            {
                if (product.Name == null)
                {
                    return false;
                }
                if (product.Name.ToUpper().Equals(name.ToUpper()))
                {
                    return true;
                }
                return false;
            });

            if (product == null)
            {
                return null;
            }

            return product.ToProductResponse();
        }
    }
}
