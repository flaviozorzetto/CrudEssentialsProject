using CrudEssentialsProject.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CrudEssentialsProject.Interfaces
{
    public interface IProductRepository
    {
        Task<IList<ProductResponseDto>> GetAll();
        Task<ProductResponseDto?> GetByName(string name);
        Task<ProductResponseDto> Create([FromBody] ProductRequestDto productRequest);
    }
}
