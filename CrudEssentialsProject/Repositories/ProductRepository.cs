using CrudEssentialsProject.Context;
using CrudEssentialsProject.Interfaces;
using CrudEssentialsProject.Models;
using CrudEssentialsProject.Models.Dto;
using Dapper;

namespace CrudEssentialsProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperContext _dapperContext;

        public ProductRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<ProductResponseDto> Create(ProductRequestDto productRequest)
        {
            using var connection = _dapperContext.GetConnection();

            var sql = "INSERT INTO PRODUCT VALUES (@guid, @name, @description, @price, @quantity)";

            var guid = Guid.NewGuid();

            var insertedRows = await connection.ExecuteAsync(sql, new
            {
                guid,
                name = productRequest.Name,
                description = productRequest.Description,
                price = productRequest.Price,
                quantity = productRequest.Quantity
            });

            sql = "SELECT * FROM PRODUCT WHERE GUID = @guid";

            var product = await connection.QueryAsync<Product>(sql, new { guid });

            return product.First().ToProductResponse();
        }

        public async Task<IList<ProductResponseDto>> GetAll()
        {
            using var connection = _dapperContext.GetConnection();

            var sql = "SELECT * FROM PRODUCT";

            var products = await connection.QueryAsync<Product>(sql);

            return products.Select(product => product.ToProductResponse()).ToList();
        }

        public async Task<ProductResponseDto?> GetByName(string name)
        {
            using var connection = _dapperContext.GetConnection();

            var sql = "SELECT * FROM PRODUCT WHERE Name = @name";

            var product = await connection.QueryAsync<Product>(sql, new { name });

            if (product.Count() != 1)
            {
                return null;
            }

            return product.First().ToProductResponse();
        }
    }
}
