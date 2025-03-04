using Abstractions.Models;

namespace Abstractions.Interfaces.DA
{
    public interface IServicesDA
    {
        Task<IEnumerable<Services>> Get();
        Task<Services> Get(int Id);
        Task<int> Add(ServicesRequest services);
        Task<int> Update(Services services);
        Task<int> Delete(int Id);
    }
}
