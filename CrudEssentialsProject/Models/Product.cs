namespace CrudEssentialsProject.Models
{
    public class Product
    {
        public Guid Guid { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
