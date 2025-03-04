using Abstractions.Interfaces.DA;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DA.Repositories
{
    public class DapperRepository : IDapperRepositoryDA
    {
        private readonly IConfiguration _configuration;
        public SqlConnection _dataBaseConnection { get; }

        public DapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _dataBaseConnection = new SqlConnection(_configuration.GetConnectionString("BD"));
        }

        public SqlConnection GetDapperRepository()
        {
            return _dataBaseConnection;
        }
    }
}
