using Abstractions.Models;

namespace Abstractions.Interfaces.DA
{
    public interface IPeopleDA
    {
        Task<IEnumerable<People>> Get();
        Task<People> Get(int Id);
        Task<int> Add(PeopleRequest people);
        Task<int> Update(People people);
        Task<int> Delete(int Id);
    }
}
