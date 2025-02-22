using Abstractions.Interfaces.DA;
using Abstractions.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DA
{
    public class PeopleDA : IPeopleDA
    {
        private IDapperRepositoryDA _dapperRepository;
        private SqlConnection _sqlConnection;

        public PeopleDA(IDapperRepositoryDA dapperRepository)
        {
            _dapperRepository = dapperRepository;
            _sqlConnection = _dapperRepository.GetDapperRepository();
        }

        public async Task<int> Add(PeopleRequest people)
        {
            string sql = @"Add_People";
            var result = await _sqlConnection.ExecuteScalarAsync<int>(sql,
                new
                {
                    Name = people.Name,
                    FirstLastName = people.FirstLastName,
                    City = people.City,
                    Address = people.Address,
                    PhoneNumber = people.PhoneNumber,
                    Created_At = people.CreatedAt,
                });
            return result;
        }

        public async Task<int> Delete(int Id)
        {
            string sql = @"Delete_People";
            var consultResultTemp = await Get(Id);
            if (consultResultTemp == null)
                return 0;
            var result = await _sqlConnection.ExecuteScalarAsync<int>(sql, new { Id = Id });
            return result;
        }

        public async Task<IEnumerable<People>> Get()
        {
            string sql = @"SELECT * FROM Get_People_View";
            var result = await _sqlConnection.QueryAsync<People>(sql);
            return result;
        }

        public async Task<People> Get(int Id)
        {
            string sql = @"Get_People_By_Id";
            var result = await _sqlConnection.QueryAsync<People>(sql, new { Id = Id });
            if (result.FirstOrDefault() == null)
                return null;
            return result.FirstOrDefault();
        }

        public async Task<int> Update(People people)
        {
            string sql = @"Update_People";
            var resultTemp = await Get(people.Id);
            if (resultTemp == null)
                return 0;
            var result = await _sqlConnection.ExecuteScalarAsync<int>(sql,
                new
                {
                    Id=people.Id,
                    Name = people.Name,
                    FirstLastName = people.FirstLastName,
                    City = people.City,
                    Address = people.Address,
                    PhoneNumber = people.PhoneNumber
                });
            return result;
        }
    }
}
