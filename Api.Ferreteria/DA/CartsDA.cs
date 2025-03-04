using Abstractions.Interfaces.DA;
using Abstractions.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class CartsDA : ICartsDA
    {
        private IDapperRepositoryDA _dapperRepository;
        private SqlConnection _sqlConnection;

        public CartsDA(IDapperRepositoryDA dapperRepository)
        {
            _dapperRepository = dapperRepository;
            _sqlConnection = _dapperRepository.GetDapperRepository();
        }

        public async Task<Guid> Add(CartsRequest carts)
        {
            string sql = @"Add_Carts";
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    IdUser = carts.IdUser,
                    DateCreated = carts.DateCreated
                });
            return result;
        }

        public async Task<Guid> Delete(Guid Id)
        {
            string sql = @"Delete_Carts";
            var consultResultTemp = await Get(Id);
            if (consultResultTemp == null)
                return Guid.Empty;
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql, new { Id = Id });
            return result;
        }

        public async Task<IEnumerable<Carts>> Get()
        {
            string sql = @"SELECT * FROM Get_Carts_View";
            var result = await _sqlConnection.QueryAsync<Carts>(sql);
            return result;
        }

        public async Task<Carts> Get(Guid Id)
        {
            string sql = @"Get_Cart_By_Id";
            var result = await _sqlConnection.QueryAsync<Carts>(sql, new { Id = Id });
            if (result.FirstOrDefault() == null)
                return null;
            return result.FirstOrDefault();
        }

        public async Task<Guid> Update(Carts carts)
        {
            string sql = @"Update_Carts";
            var resultTemp = await Get(carts.Id);
            if (resultTemp == null)
                return Guid.Empty;
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    Id = carts.Id,
                    IdUser = carts.IdUser,
                    DateCreated = carts.DateCreated
                });
            return result;
        }
    }
}
