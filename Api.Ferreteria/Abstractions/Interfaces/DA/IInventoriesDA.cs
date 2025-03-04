using Abstractions.Models;

namespace Abstractions.Interfaces.DA
{
    public interface IInventoriesDA
    {
        Task<IEnumerable<Inventories>> Get();
        Task<Inventories> Get(int Id);
        Task<int> Add(InventoriesRequest inventories);
        Task<int> Update(Inventories inventories);
        Task<int> Delete(int Id);
    }
}
