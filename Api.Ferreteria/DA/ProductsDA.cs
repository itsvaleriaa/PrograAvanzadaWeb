using Abstractions.Interfaces.DA;
using Abstractions.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class ProductsDA : IProductsDA
    {
        private IDapperRepositoryDA _dapperRepository;
        private SqlConnection _sqlConnection;

        public ProductsDA(IDapperRepositoryDA dapperRepository)
        {
            _dapperRepository = dapperRepository;
            _sqlConnection = _dapperRepository.GetDapperRepository();
        }

        public async Task<Guid> Add(ProductsRequest products)
        {
            string sql = @"Add_Products";
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    Name = products.Name,
                    Description = products.Description,
                    Price = products.Price,
                    Photo = products.Photo,
                    Created_at = products.Created_at,
                    this_id_user_create = products.this_id_user_create
                });
            return result;
        }

        public async Task<Guid> Delete(Guid Id)
        {
            string sql = @"Delete_Products";
            var consultResultTemp = await Get(Id);
            if (consultResultTemp == null)
                return Guid.Empty;
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql, new { Id = Id });
            return result;
        }

        public async Task<IEnumerable<Products>> Get()
        {
            string sql = @"SELECT * FROM Get_Products_View";
            var result = await _sqlConnection.QueryAsync<Products>(sql);
            return result;
        }

        public async Task<Products> Get(Guid Id)
        {
            string sql = @"Get_Product_By_Id";
            var result = await _sqlConnection.QueryAsync<Products>(sql, new { Id = Id });
            if (result.FirstOrDefault() == null)
                return null;
            return result.FirstOrDefault();
        }

        public async Task<Guid> Update(Products products)
        {
            string sql = @"Update_Products";
            var resultTemp = await Get(products.Id);
            if (resultTemp == null)
                return Guid.Empty;
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    Id = products.Id,
                    Name = products.Name,
                    Description = products.Description,
                    Price = products.Price,
                    Photo = products.Photo,
                    Updated_at = products.Updated_at,
                    this_id_user_create = products.this_id_user_create
                });
            return result;
        }
    }
}
