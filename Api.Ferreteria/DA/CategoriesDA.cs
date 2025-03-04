using Abstractions.Interfaces.DA;
using Abstractions.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class CategoriesDA : ICategoriesDA
    {
        private IDapperRepositoryDA _dapperRepository;
        private SqlConnection _sqlConnection;

        public CategoriesDA(IDapperRepositoryDA dapperRepository)
        {
            _dapperRepository = dapperRepository;
            _sqlConnection = _dapperRepository.GetDapperRepository();
        }

        public async Task<int> Add(CategoriesRequest categories)
        {
            string sql = @"Add_Categories";
            var result = await _sqlConnection.ExecuteScalarAsync<int>(sql,
                new
                {
                    Name = categories.Name
                });
            return result;
        }

        public async Task<int> Delete(int Id)
        {
            string sql = @"Delete_Categories";
            var consultResultTemp = await Get(Id);
            if (consultResultTemp == null)
                return 0;
            var result = await _sqlConnection.ExecuteScalarAsync<int>(sql, new { Id = Id });
            return result;
        }

        public async Task<IEnumerable<Categories>> Get()
        {
            string sql = @"SELECT * FROM Get_Categories_View";
            var result = await _sqlConnection.QueryAsync<Categories>(sql);
            return result;
        }

        public async Task<Categories> Get(int Id)
        {
            string sql = @"Get_Category_By_Id";
            var result = await _sqlConnection.QueryAsync<Categories>(sql, new { Id = Id });
            if (result.FirstOrDefault() == null)
                return null;
            return result.FirstOrDefault();
        }

        public async Task<int> Update(Categories categories)
        {
            string sql = @"Update_Categories";
            var resultTemp = await Get(categories.Id);
            if (resultTemp == null)
                return 0;
            var result = await _sqlConnection.ExecuteScalarAsync<int>(sql,
                new
                {
                    Id = categories.Id,
                    Name = categories.Name
                });
            return result;
        }
    }
}
