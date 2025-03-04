using Abstractions.Models;

namespace Abstractions.Interfaces.BW
{
    public interface IInventoriesBW
    {
        Task<IEnumerable<Inventories>> Get();
        Task<Inventories> Get(int Id);
        Task<int> Add(InventoriesRequest inventories);
        Task<int> Update(Inventories inventories);
        Task<int> Delete(int Id);
    }
}
