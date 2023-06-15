using CrudEssentialsProject.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CrudEssentialsProject.Interfaces
{
    public interface IProductRepository
    {
        Task<IList<ProductResponse>> GetAll();
        Task<ProductResponse?> GetByName(string name);
        Task<ProductResponse> Create([FromBody] ProductRequest productRequest);
    }
}
