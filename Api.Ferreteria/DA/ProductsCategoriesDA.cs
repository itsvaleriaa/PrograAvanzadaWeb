using Abstractions.Interfaces.DA;
using Abstractions.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class ProductsCategoriesDA : IProductsCategoriesDA
    {
        private IDapperRepositoryDA _dapperRepository;
        private SqlConnection _sqlConnection;

        public ProductsCategoriesDA(IDapperRepositoryDA dapperRepository)
        {
            _dapperRepository = dapperRepository;
            _sqlConnection = _dapperRepository.GetDapperRepository();
        }

        public async Task<Guid> Add(ProductsCategories productsCategories)
        {
            string sql = @"Add_ProductsCategories";
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    IdProduct = productsCategories.IdProduct,
                    IdCategory = productsCategories.IdCategory,
                });
            return result;
        }

        public async Task<Guid> Delete(Guid IdProduct, int IdCategory)
        {
            string sql = @"Delete_ProductsCategories";
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    IdProduct = IdProduct,
                    IdCategory = IdCategory
                });
            if (result == Guid.Empty)
                return Guid.Empty;
            return result;
        }

        public async Task<IEnumerable<ProductsCategories>> Get()
        {
            string sql = @"SELECT * FROM Get_ProductsCategories_View";
            var result = await _sqlConnection.QueryAsync<ProductsCategories>(sql);
            return result;
        }
    }
}
