using Microsoft.Data.SqlClient;

namespace Abstractions.Interfaces.DA
{
    public interface IDapperRepositoryDA
    {
        SqlConnection GetDapperRepository();
    }
}
