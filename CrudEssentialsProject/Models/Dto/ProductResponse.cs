namespace CrudEssentialsProject.Models.Dto
{
    public class ProductResponse
    {
        public Guid Guid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
    }

    public static class ProductExtensions
    {
        public static ProductResponse ToProductResponse(this Product product)
        {
            ProductResponse productResponse = new ProductResponse()
            {
                Guid = product.Guid,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
            };
            return productResponse;
        }
    }
}
