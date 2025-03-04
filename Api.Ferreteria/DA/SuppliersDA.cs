using Abstractions.Interfaces.DA;
using Abstractions.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class SuppliersDA : ISuppliersDA
    {
        private IDapperRepositoryDA _dapperRepository;
        private SqlConnection _sqlConnection;

        public SuppliersDA(IDapperRepositoryDA dapperRepository)
        {
            _dapperRepository = dapperRepository;
            _sqlConnection = _dapperRepository.GetDapperRepository();
        }

        public async Task<Guid> Add(SuppliersRequest suppliers)
        {
            string sql = @"Add_Suppliers";
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    Name = suppliers.Name,
                    City = suppliers.City,
                    Address = suppliers.Address,
                    PhoneNumber = suppliers.PhoneNumber,
                    Email = suppliers.Email,
                    Representative = suppliers.Representative,
                    this_id_user_create = suppliers.This_id_user_create
                });
            return result;
        }

        public async Task<Guid> Delete(Guid Id)
        {
            string sql = @"Delete_Suppliers";
            var consultResultTemp = await Get(Id);
            if (consultResultTemp == null)
                return Guid.Empty;
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql, new { Id = Id });
            return result;
        }

        public async Task<IEnumerable<Suppliers>> Get()
        {
            string sql = @"SELECT * FROM Get_Suppliers_View";
            var result = await _sqlConnection.QueryAsync<Suppliers>(sql);
            if (!result.Any())
                return null;
            return result;
        }

        public async Task<Suppliers> Get(Guid Id)
        {
            string sql = @"Get_Supplier_By_Id";
            var result = await _sqlConnection.QueryAsync<Suppliers>(sql, new { Id = Id });
            if (!result.Any())
                return null;
            return result.FirstOrDefault();
        }

        public async Task<Guid> Update(Suppliers suppliers)
        {
            string sql = @"Update_Suppliers";
            var resultTemp = await Get(suppliers.Id);
            if (resultTemp == null)
                return Guid.Empty;
            var result = await _sqlConnection.ExecuteScalarAsync<Guid>(sql,
                new
                {
                    Id = suppliers.Id,
                    Name = suppliers.Name,
                    City = suppliers.City,
                    Address = suppliers.Address,
                    PhoneNumber = suppliers.PhoneNumber,
                    Email = suppliers.Email,
                    Representative = suppliers.Representative,
                    this_id_user_create = suppliers.This_id_user_create
                });
            return result;
        }
    }
}
