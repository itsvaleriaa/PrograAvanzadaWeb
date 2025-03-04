using Abstractions.Interfaces.DA;
using Abstractions.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class CartServiceDA : ICartServiceDA
    {
        private IDapperRepositoryDA _dapperRepository;
        private SqlConnection _sqlConnection;

        public CartServiceDA(IDapperRepositoryDA dapperRepository)
        {
            _dapperRepository = dapperRepository;
            _sqlConnection = _dapperRepository.GetDapperRepository();
        }

        public async Task<Guid> Add(CartService cartService)
        {
            string sql = @"Add_CartService";
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    IdCart = cartService.IdCart,
                    IdService = cartService.IdService,
                });
            return result;
        }

        public async Task<Guid> Delete(Guid Id)
        {
            string sql = @"Delete_CartService";
            var consultResultTemp = await Get(Id);
            if (consultResultTemp == null)
                return Guid.Empty;
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql, new { Id = Id });
            return result;
        }

        public async Task<IEnumerable<CartService>> Get()
        {
            string sql = @"SELECT * FROM Get_CartService_View";
            var result = await _sqlConnection.QueryAsync<CartService>(sql);
            return result;
        }

        public async Task<CartService> Get(Guid Id)
        {
            string sql = @"Get_CartService_By_Id";
            var result = await _sqlConnection.QueryAsync<CartService>(sql, new { IdCart = Id });
            if (result.FirstOrDefault() == null)
                return null;
            return result.FirstOrDefault(); ;
        }

        public async Task<Guid> Update(CartService cartService)
        {
            string sql = @"Update_CartService";
            var resultTemp = await Get(cartService.IdCart);
            if (resultTemp == null)
                return Guid.Empty;
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    IdCart = cartService.IdCart,
                    IdService = cartService.IdService,
                });
            return result;
        }
    }
}
