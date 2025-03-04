using Abstractions.Interfaces.DA;
using Abstractions.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class CartsxProductsDA : ICartsxProductsDA
    {
        private IDapperRepositoryDA _dapperRepository;
        private SqlConnection _sqlConnection;

        public CartsxProductsDA(IDapperRepositoryDA dapperRepository)
        {
            _dapperRepository = dapperRepository;
            _sqlConnection = _dapperRepository.GetDapperRepository();
        }

        public async Task<Guid> Add(CartsxProducts cartsxProducts)
        {
            string sql = @"Add_CartsxProducts";
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    IdProduct = cartsxProducts.IdProduct,
                    Amount = cartsxProducts.Amount,
                });
            return result;
        }

        public async Task<Guid> Delete(Guid Id)
        {
            string sql = @"Delete_CartsxProducts";
            var consultResultTemp = await Get(Id);
            if (consultResultTemp == null)
                return Guid.Empty;
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql, new { Id = Id });
            return result;
        }

        public async Task<IEnumerable<CartsxProducts>> Get()
        {
            string sql = @"SELECT * FROM Get_CartsxProducts_View";
            var result = await _sqlConnection.QueryAsync<CartsxProducts>(sql);
            return result;
        }

        public async Task<CartsxProducts> Get(Guid Id)
        {
            string sql = @"Get_CartsxProducts_By_IdCart";
            var result = await _sqlConnection.QueryAsync<CartsxProducts>(sql, new { Id = Id });
            if (result.FirstOrDefault() == null)
                return null;
            return result.FirstOrDefault();
        }

        public async Task<Guid> Update(CartsxProducts cartsxProducts)
        {
            string sql = @"Update_CartsxProducts";
            var resultTemp = await Get(cartsxProducts.IdCart);
            if (resultTemp == null)
                return Guid.Empty;
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    IdCart = cartsxProducts.IdCart,
                    IdProduct = cartsxProducts.IdProduct,
                    Amount = cartsxProducts.Amount
                });
            return result;
        }
    }
}
